using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CencusAnalyserProgram
{
    public class OpenCSVBuilder : ICSVBuilder
    {

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

    }
}
