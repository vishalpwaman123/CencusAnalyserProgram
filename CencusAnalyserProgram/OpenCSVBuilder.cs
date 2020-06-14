using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CencusAnalyserProgram
{
    public class OpenCSVBuilder : ICSVBuilder
    {

        public List<CencusDAO> CencusList = new List<CencusDAO>();
        public Dictionary<string, CencusDAO> dictionaryCensus = new Dictionary<string, CencusDAO>();

        /// <summary>
        /// This Method is Used to Load both Census And StateCode data
        /// </summary>
        /// <param name="csvData">csvData parameter is the object of DataTable to store the loaded data</param>
        /// <param name="path">path parameter contains the path of the CSV File</param>
        /// <returns>It returns the loaded data</returns>


        public DataTable DataLoader(string csvFilePath)
        {

            DataTable csvData = new DataTable();
            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (IndexOutOfRangeException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.HEADER_INCORRECT);
            }
            catch (Exception ex)
            {
            }
            return csvData;

        }

        public List<CencusDAO> UsDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.stateId = (csvCensusData.Rows[row]["State_Id"].ToString());
                cencusCsv.state = (csvCensusData.Rows[row]["State"].ToString());
                cencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                cencusCsv.totalArea = Convert.ToDouble(csvCensusData.Rows[row]["Total_area"].ToString());
                cencusCsv.populationDencity = Convert.ToDouble(csvCensusData.Rows[row]["Population_Density"].ToString());
                CencusList.Add(cencusCsv);
                row++;
            }
            return CencusList;
        }

        public List<CencusDAO> IndianStateDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.srNo = Convert.ToInt32(csvCensusData.Rows[row]["SrNo"]);
                cencusCsv.state = (csvCensusData.Rows[row]["State Name"].ToString());
                cencusCsv.tin = Convert.ToInt32(csvCensusData.Rows[row]["TIN"].ToString());
                cencusCsv.stateCode = csvCensusData.Rows[row]["StateCode"].ToString();
                CencusList.Add(cencusCsv);
                row++;
            }
            return CencusList;
        }

        public List<CencusDAO> CensusDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[row]["AreaInSqKm"].ToString());
                cencusCsv.dencityPerSqKm = Convert.ToInt32(csvCensusData.Rows[row]["DensityPerSqKm"].ToString());
                cencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                cencusCsv.state = csvCensusData.Rows[row]["State"].ToString();
                CencusList.Add(cencusCsv);
                row++;
            }
            return CencusList;
        }
    }

}

