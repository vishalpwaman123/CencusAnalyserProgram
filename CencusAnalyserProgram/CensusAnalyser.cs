using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CencusAnalyserProgram;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;


namespace CencusAnalyserProgram
{
    public class CensusAnalyser : Exception
    {

        public List<CencusDAO> CencusList = new List<CencusDAO>();
        public Dictionary<string, CencusDAO> dictionaryCensus = new Dictionary<string, CencusDAO>();
        DataTable csvCensusData = new DataTable();
        ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
        
        /// <summary>
        /// This Method takes the input path of File and give to the LoadData Method Constructor
        /// </summary>
        /// <param name="path">path parameter contains the path of File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>

        public CensusAnalyser(string path)
        {
            try
            {
                csvCensusData = cSVBuilder.DataLoader(path);
            }catch(FileNotFoundException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the CensusDataAssigned Method 
        /// </summary>
        /// <returns>It returns the CensusDataAssigned in List format and return ConvertListToDictionary in Integer Formate</returns>
        public int LoadIndiaCensusData()
        {
            
            CencusList = cSVBuilder.CensusDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the IndianStateDataAssigned Method 
        /// </summary>
        /// <returns>It returns the IndianStateDataAssigned in List format and return ConvertListToDictionary in Integer Formate</returns>
        public int LoadIndiaStateCode()
        { 
            CencusList = cSVBuilder.IndianStateDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the UsDataAssigned Method 
        /// </summary>
        /// <returns>It returns the UsDataAssigned in List format and return ConvertListToDictionary in Integer Formate</returns>
        public int LoadUsCencusData()
        {
            CencusList = cSVBuilder.UsDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        /// <summary>
        /// This Method takes the List<CencusDAO> input 
        /// </summary>
        /// <param name="path">path parameter contains the List<CencusDAO> Parameter</param>
        /// <returns>It returns the dictionaryCensus in Integer Formate</returns>
        private int ConvertListToDictionary(List<CencusDAO> CencusList)
        {
            dictionaryCensus = CencusList.ToDictionary(x => x.state);
            return dictionaryCensus.Count();
        }

        /// <summary>
        /// This Method takes the Dictionary<string, CencusDAO> input 
        /// </summary>
        /// <param name="path">path parameter contains the Dictionary<string, CencusDAO> Parameter</param>
        /// <returns>It returns the dictionaryCensus in boolean Formate Or Exception Throws</returns>
        public Boolean EmptyDictionary(Dictionary<string, CencusDAO> dictionaryCensus)
        {
            if (dictionaryCensus == null || dictionaryCensus.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            return true;
        }

        /// <summary>
        /// This Method takes the json File path, key, index input 
        /// </summary>
        /// <param name="path">path parameter contains the String And Integer Parameter</param>
        /// <returns>It returns the RetriveDataOnKey in integer Formate </returns>
        public string GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.dencityPerSqKm);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        /// <summary>
        /// This Method takes the json File path, key, index input 
        /// </summary>
        /// <param name="path">path parameter contains the String And Integer Parameter</param>
        /// <returns>It returns the RetriveDataOnKey in integer Formate </returns>
        public string GetSortedCensusData(string jsonFilepath, string key, int index)
        {
            
            EmptyDictionary(dictionaryCensus);
            switch (key)
            {
                case "state":
                    object listAlphabetically1= CencusList.OrderBy(x => x.state);
                    var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically1, Formatting.Indented);
                    File.WriteAllText(jsonFilepath, dataInJsonFormat);

                    break;

                case "totalArea":
                    object listAlphabetically2 = CencusList.OrderBy(x => x.totalArea);
                    var dataInJsonFormat1 = JsonConvert.SerializeObject(listAlphabetically2, Formatting.Indented);
                    File.WriteAllText(jsonFilepath, dataInJsonFormat1);

                    break;

                case "populationDencity":
                    object listAlphabetically3 = CencusList.OrderBy(x => x.populationDencity);
                    var dataInJsonFormat2 = JsonConvert.SerializeObject(listAlphabetically3, Formatting.Indented);
                    File.WriteAllText(jsonFilepath, dataInJsonFormat2);

                    break;

                case "dencityPerSqKm":
                    object listAlphabetically4 = CencusList.OrderBy(x => x.dencityPerSqKm);
                    var dataInJsonFormat4 = JsonConvert.SerializeObject(listAlphabetically4, Formatting.Indented);
                    File.WriteAllText(jsonFilepath, dataInJsonFormat4);

                    break;

                case "population":
                    object listAlphabetically5 = CencusList.OrderBy(x => x.population);
                    var dataInJsonFormat5 = JsonConvert.SerializeObject(listAlphabetically5, Formatting.Indented);
                    File.WriteAllText(jsonFilepath, dataInJsonFormat5);

                    break;
            }
          
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        /// <summary>
        /// This Method takes the json File path, key, index input 
        /// </summary>
        /// <param name="path">path parameter contains the String And Integer Parameter</param>
        /// <returns>It returns the RetriveDataOnKey in integer Formate </returns>
        private static string RetriveDataOnKey(string jsonPath, string key, int index)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val = jArray[index][key].ToString();
            return val;
        }

    }
 }

