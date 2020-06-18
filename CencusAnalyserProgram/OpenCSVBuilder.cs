// <copyright file="OpenCSVBuilder.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualBasic.FileIO;

    /// <summary>
    /// Declare Class
    /// </summary>
    public class OpenCSVBuilder : ICSVBuilder
    {
        /// <summary>
        /// Declare List Object
        /// </summary>
        private List<CencusDAO> cencusList = new List<CencusDAO>();

        /// <summary>
        /// Declare Dictionary Object
        /// </summary>
        private Dictionary<string, CencusDAO> dictionaryCensus = new Dictionary<string, CencusDAO>();

        /// <summary>
        /// This Method is Used to Load both Census And StateCode data
        /// </summary>
        /// <param name="csvFilePath">Passing Argument</param>
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
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == " ")
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
            catch (NullReferenceException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.NULL_PATH_NOT_ALLOW);
            }
            catch (ArgumentNullException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            catch (Exception e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR);
            }

            return csvData;
        }

        /// <summary>
        /// This Method is Used to Load Us data
        /// </summary>
        /// <param name="csvCensusData">path parameter contains the path of the DataTable Variable</param>
        /// <returns>It returns the loaded data List</returns>
        public List<CencusDAO> UsDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.StateId = csvCensusData.Rows[row]["State_Id"].ToString();
                cencusCsv.State = csvCensusData.Rows[row]["State"].ToString();
                cencusCsv.Population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                cencusCsv.TotalArea = Convert.ToDouble(csvCensusData.Rows[row]["Total_area"].ToString());
                cencusCsv.PopulationDencity = Convert.ToDouble(csvCensusData.Rows[row]["Population_Density"].ToString());
                this.cencusList.Add(cencusCsv);
                row++;
            }

            return this.cencusList;
        }

        /// <summary>
        /// This Method is Used to Load Indian State Data
        /// </summary>
        /// <param name="csvCensusData">path parameter contains the path of the DataTable File</param>
        /// <returns>It returns the loaded data List</returns>
        public List<CencusDAO> IndianStateDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.SrNo = Convert.ToInt32(csvCensusData.Rows[row]["SrNo"]);
                cencusCsv.State = csvCensusData.Rows[row]["State Name"].ToString();
                cencusCsv.Tin = Convert.ToInt32(csvCensusData.Rows[row]["TIN"].ToString());
                cencusCsv.StateCode = csvCensusData.Rows[row]["StateCode"].ToString();
                this.cencusList.Add(cencusCsv);
                row++;
            }

            return this.cencusList;
        }

        /// <summary>
        /// This Method is Used to Load Census Data
        /// </summary>
        /// <param name="csvCensusData">path parameter contains the path of the DataTable</param>
        /// <returns>It returns the loaded data List</returns>
        public List<CencusDAO> CensusDataAssigned(DataTable csvCensusData)
        {
            int row = 0;
            while (row < csvCensusData.Rows.Count)
            {
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.AreaInSqKm = Convert.ToInt32(csvCensusData.Rows[row]["AreaInSqKm"].ToString());
                cencusCsv.DencityPerSqKm = Convert.ToInt32(csvCensusData.Rows[row]["DensityPerSqKm"].ToString());
                cencusCsv.Population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                cencusCsv.State = csvCensusData.Rows[row]["State"].ToString();
                this.cencusList.Add(cencusCsv);
                row++;
            }

            return this.cencusList;
        }
    }
}
