using NUnit.Framework;
using CencusAnalyserProgram;
using System.Data;
using Newtonsoft.Json.Linq;
using System;

namespace CencusAnalyserTest
{
    public class Tests
    {
        /// <summary>
        /// Used string variables to store the csv file paths
        /// </summary>
        
        private static string INDIA_CENSUS_CSV_FILE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.csv";
        private static string WRONG_CSV_FILE_PATH = @"./src/main/resources/IndiaStateCensusData.csv";
        private static string WRONG_CSV_FILE_EXTENSION = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.pdf";
        private static string INDIA_STATE_CODE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCode.csv";
        private static string WORNG_INDIA_STATE_CODE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/IndiaStateCode.csv";
        private static string WRONG_STATE_CODE_FILE_EXTENSION = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCode.jpg";
        public string INDIAN_STATE_CENSUS_JSON_PATH= @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCensusData.JSON";
        public string INDIAN_STATE_CODE_JSON_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCode.JSON";
        private static string US_CENSUS_FILE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/USCensusData.csv";
        public string US_CENCUS_JSON_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/UsCencusJsonFile.JSON";

        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>

        [Test]
        public void givenIndianCensusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int csvDatacount = censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            Assert.AreEqual(29,csvDatacount);
            
        }


        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>


        [Test]
        public void givenIndiaCensusData_WhenWrongPathName_shouldThrowCustomException() 
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(WRONG_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM, e.type);
            }
            
        }


        /// <summary>
        /// Given file path with incorrect extension type to load the data should throw exception
        /// </summary>


        [Test]
        public void givenIndiaCensusData_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(WRONG_CSV_FILE_EXTENSION);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_WRONGE_EXTENSION, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimeter to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndiaCensusData_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(WRONG_CSV_FILE_EXTENSION);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMETER_INCORRECT_EXCEPTION, e.type);
            }

        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianCensusCSVData__WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.type);
            }
        }


        /// <summary>
        /// Load the Indian Statem Code File and Check For the number of records present in the file
        /// </summary>


        [Test]
        public void givenIndianStateCode_CSVFile_ShouldReturnsCorrectRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int csvstateData = censusAnalyser.LoadIndiaStateCode(INDIA_STATE_CODE_PATH);
            Assert.AreEqual(37, csvstateData);
        }


        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianStateCode_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCode(WORNG_INDIA_STATE_CODE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM, e.type);
            }

        }

        /// <summary>
        /// Given file path with incorrect extension type to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianStateCode_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCode(WRONG_STATE_CODE_FILE_EXTENSION);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_WRONGE_EXTENSION, e.type);
            }
        }

        /// <summary>
        /// Given file with incorrect Delimeter to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndiaStateCode_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCode(INDIA_STATE_CODE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMETER_INCORRECT_EXCEPTION, e.type);
            }

        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianStateCode_WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.LoadIndiaStateCode(INDIA_STATE_CODE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.type);
            }
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH,"state",0);
            Assert.AreEqual("Andhra Pradesh",sortedData);
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "state", 28);
            Assert.AreEqual("West Bengal", sortedData);

        }

        [Test]
        public void givenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaStateCode(INDIA_STATE_CODE_PATH);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedData(INDIAN_STATE_CODE_JSON_PATH, "state", 0);
            Assert.AreEqual("Andaman and Nicobar Islands", sortedData);
        }

        [Test]
        public void givenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaStateCode(INDIA_STATE_CODE_PATH);
            string sortedData = censusAnalyser.GetStateCodeWiseSortedData(INDIAN_STATE_CODE_JSON_PATH, "state", 36);
            Assert.AreEqual("West Bengal", sortedData);
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "population", 0);
            Assert.AreEqual("607688", sortedData);
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnPopulationDencity()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationDencityWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "dencityPerSqKm", 0);
            Assert.AreEqual("50", sortedData);
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLargetArea()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "areaInSqKm",28);
            Assert.AreEqual("240928", sortedData);
        }

        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestPopulation()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationWiseSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "population", 28);
            Assert.AreEqual("199812341", sortedData);
        }

        [Test]
        public void givenUsCencusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            int csvstateData = censusAnalyser.LoadUsCencusData(US_CENSUS_FILE_PATH);
            Assert.AreEqual(51, csvstateData);
        }

        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCencusData(US_CENSUS_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationWiseSortedUsCensusData(US_CENCUS_JSON_PATH, "population", 0);
            Assert.AreEqual("563626", sortedData);
        }

        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestPopulation()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser();
            censusAnalyser.LoadUsCencusData(US_CENSUS_FILE_PATH);
            string sortedData = censusAnalyser.GetpopulationWiseSortedUsCensusData(US_CENCUS_JSON_PATH, "population", 50);
            Assert.AreEqual("37253956", sortedData);
        }

    }
}