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
        
        
        //public List<CencusDAO> indiaStateCodeList = new List<CencusDAO>();
        public List<CencusDAO> CencusList = new List<CencusDAO>();

        public Dictionary<string, CencusDAO> dictionaryCensus = new Dictionary<string, CencusDAO>();

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
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[row]["AreaInSqKm"].ToString());
                cencusCsv.dencityPerSqKm = Convert.ToInt32(csvCensusData.Rows[row]["DensityPerSqKm"].ToString());
                cencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                cencusCsv.state = csvCensusData.Rows[row]["State"].ToString();
                CencusList.Add(cencusCsv);
                row++;
            }
            dictionaryCensus = CencusList.ToDictionary(x => x.state);
            return dictionaryCensus.Count();
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
                CencusDAO cencusCsv = new CencusDAO();
                cencusCsv.srNo = Convert.ToInt32(csvCensusData.Rows[row]["SrNo"]);
                cencusCsv.state = (csvCensusData.Rows[row]["State Name"].ToString());
                cencusCsv.tin = Convert.ToInt32(csvCensusData.Rows[row]["TIN"].ToString());
                cencusCsv.stateCode = csvCensusData.Rows[row]["StateCode"].ToString();
                CencusList.Add(cencusCsv);
                row++;
            }

            dictionaryCensus = CencusList.ToDictionary(x => x.state);
            return dictionaryCensus.Count();
        }

        public int LoadUsCencusData(string path)
        {
            int row = 0;
            DataTable csvCensusData = new DataTable();
            ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = cSVBuilder.DataLoader(path);
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
            dictionaryCensus = CencusList.ToDictionary(x => x.state);
            return dictionaryCensus.Count();

        }

        public Boolean EmptyDirectory(Dictionary<string, CencusDAO> dictionaryCensus)
        {
            if (dictionaryCensus == null || dictionaryCensus.Count() == 0)
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            return true;
        }
        public string GetStateCodeWiseSortedCensusData(string jsonFilepath,string key,int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.state);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key,index);
        }

        public string GetStateCodeWiseSortedData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.state);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationWiseSortedCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.population);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationDencityWiseSortedCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.dencityPerSqKm);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.population);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GetpopulationDencityWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
            object listAlphabetically = CencusList.OrderBy(x => x.populationDencity);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return RetriveDataOnKey(jsonFilepath, key, index);
        }

        public string GettotalAreaWiseSortedUsCensusData(string jsonFilepath, string key, int index)
        {

            EmptyDirectory(dictionaryCensus);
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

