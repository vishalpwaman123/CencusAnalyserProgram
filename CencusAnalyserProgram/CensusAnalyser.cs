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
        
        public List<IndianCencusCSV> indiancensusList = new List<IndianCencusCSV>();
        public List<IndianStateCodeCSV> indiaStateCodeList = new List<IndianStateCodeCSV>();
        public List<UsCencusCSV> UsCencusList = new List<UsCencusCSV>();

        //public Dictionary<string, CensusDAO> csvFileMap = new Dictionary<string, CensusDAO>();

        /// <summary>
        /// This Method takes the input path of Indian Census Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of India Census CSV File</param>
        /// <returns>It returns the LoadedData in integer format</returns>

        public int LoadIndiaCensusData(string path)
        {
            int row = 0;
            DataTable csvCensusData = new DataTable();
            ICSVBuilder csvBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = csvBuilder.DataLoader(path);

            while (row < csvCensusData.Rows.Count)
            {
                IndianCencusCSV indianCencusCsv = new IndianCencusCSV();
                indianCencusCsv.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[row]["AreaInSqKm"].ToString());
                indianCencusCsv.dencityPerSqKm = Convert.ToInt32(csvCensusData.Rows[row]["DensityPerSqKm"].ToString());
                indianCencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                indianCencusCsv.state = csvCensusData.Rows[row]["State"].ToString();
                indiancensusList.Add(indianCencusCsv);
                row++;
            }
            
            return indiancensusList.Count();
        }

        /// <summary>
        /// This Method takes the input path of Indian State Code Csv File and give to the LoadData Method
        /// </summary>
        /// <param name="path">path parameter contains the path of Indian State Code CSV File</param>
        /// <returns>It returns the LoadedData in integer format</returns>


        public int LoadIndiaStateCode(string path)
        {
            int row = 0;
            DataTable csvCensusData = new DataTable();
            ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = cSVBuilder.DataLoader(path);
            while (row < csvCensusData.Rows.Count)
            {
                IndianStateCodeCSV indianStateCodeCsv = new IndianStateCodeCSV();
                indianStateCodeCsv.srNo = Convert.ToInt32(csvCensusData.Rows[row]["SrNo"]);
                indianStateCodeCsv.state = (csvCensusData.Rows[row]["State Name"].ToString());
                indianStateCodeCsv.tin = Convert.ToInt32(csvCensusData.Rows[row]["TIN"].ToString());
                indianStateCodeCsv.stateCode = csvCensusData.Rows[row]["StateCode"].ToString();
                indiaStateCodeList.Add(indianStateCodeCsv);
                row++;
            }
            
            //foreach (indiaStateCodeList->csvFileMap.put(indiaStateCodeList.state, new CensusDAO(indiaStateCodeList))) ;
            return indiaStateCodeList.Count();
        }

        public int LoadUsCencusData(string path)
        {
            int row = 0;
            DataTable csvCensusData = new DataTable();
            ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = cSVBuilder.DataLoader(path);
            while (row < csvCensusData.Rows.Count)
            {
                UsCencusCSV uscencusCsv = new UsCencusCSV();
                uscencusCsv.stateId = (csvCensusData.Rows[row]["State_Id"].ToString());
                uscencusCsv.state = (csvCensusData.Rows[row]["State"].ToString());
                uscencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                uscencusCsv.totalArea = Convert.ToDouble(csvCensusData.Rows[row]["Total_area"].ToString());
                uscencusCsv.populationDencity = Convert.ToDouble(csvCensusData.Rows[row]["Population_Density"].ToString());
                UsCencusList.Add(uscencusCsv);
                row++;
            }

            //foreach (indiaStateCodeList->csvFileMap.put(indiaStateCodeList.state, new CensusDAO(indiaStateCodeList))) ;
            return UsCencusList.Count();
        }

        public string GetStateCodeWiseSortedCensusData(string jsonFilepath,string key,int index)
        {
           
            if (indiancensusList == null || indiancensusList.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found",CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            object listAlphabetically = indiancensusList.OrderBy(x => x.state);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key,index);
        }

        public string GetStateCodeWiseSortedData(string jsonFilepath, string key, int index)
        {

            if (indiaStateCodeList == null || indiaStateCodeList.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            object listAlphabetically = indiaStateCodeList.OrderBy(x => x.state);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationWiseSortedCensusData(string jsonFilepath, string key, int index)
        {

            if (indiancensusList == null || indiancensusList.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            object listAlphabetically = indiancensusList.OrderBy(x => x.population);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationDencityWiseSortedCensusData(string jsonFilepath, string key, int index)
        {

            if (indiancensusList == null || indiancensusList.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            object listAlphabetically = indiancensusList.OrderBy(x => x.dencityPerSqKm);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            if (UsCencusList == null || UsCencusList.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            object listAlphabetically = UsCencusList.OrderBy(x => x.population);
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

