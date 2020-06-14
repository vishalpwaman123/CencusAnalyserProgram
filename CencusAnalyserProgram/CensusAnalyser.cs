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
        /// This Method takes the input path of Indian Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in integer format</returns>

        public CensusAnalyser(string path)
        {
            csvCensusData = cSVBuilder.DataLoader(path);
        }

        public int LoadIndiaCensusData()
        {
            
            CencusList = cSVBuilder.CensusDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        /// <summary>
        /// This Method takes the input path of Indian State Code Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of Indian State Code CSV File</param>
        /// <returns>It returns the LoadedData in integer format</returns>


        public int LoadIndiaStateCode()
        { 
            CencusList = cSVBuilder.IndianStateDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        public int LoadUsCencusData()
        {
            CencusList = cSVBuilder.UsDataAssigned(csvCensusData);
            return ConvertListToDictionary(CencusList);
        }

        private int ConvertListToDictionary(List<CencusDAO> CencusList)
        {
            dictionaryCensus = CencusList.ToDictionary(x => x.state);
            return dictionaryCensus.Count();
        }

        public Boolean EmptyDictionary(Dictionary<string, CencusDAO> dictionaryCensus)
        {
            if (dictionaryCensus == null || dictionaryCensus.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            return true;
        }
        
        public string GetStateWiseSortedCensusData(string jsonFilepath,string key,int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.state);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key,index);
        }
      
        public string GetpopulationWiseSortedCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.population);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }
        
        public string GetpopulationDencityWiseSortedCensusDataAndIndianStateCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.dencityPerSqKm);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }
        
        public string GetpopulationDencityWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.populationDencity);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }
        
        public string GettotalAreaWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDictionary(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.totalArea);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }


        
        private static string RetriveDataOnKey(string jsonPath, string key, int index)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            string val = jArray[index][key].ToString();
            return val;
        }

    }
 }

