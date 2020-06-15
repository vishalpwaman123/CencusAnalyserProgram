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
        public string INDIAN_STATE_CENSUS_WRONG_JSON_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCensus.JSON";
        public string INDIAN_STATE_CODE_WRONG_JSON_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCoder.JSON";
        public string US_CENCUS_WRONG_JSON_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/UsCencusJson.JSON";

        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>

        [Test]
        public void givenIndianCensusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
            int csvDatacount = censusAnalyser.LoadIndiaCensusData();
            Assert.AreEqual(29,csvDatacount);
            
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void givenIndiaCensusData_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NULL_PATH_NOT_ALLOW, e.type);
            }

        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>


        [Test]
        public void givenIndiaCensusData_WhenWrongPathName_shouldThrowCustomException() 
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(WRONG_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(WRONG_CSV_FILE_EXTENSION);
                censusAnalyser.LoadIndiaCensusData();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(WRONG_CSV_FILE_EXTENSION);
                censusAnalyser.LoadIndiaCensusData();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
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
            CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_STATE_CODE_PATH);
            int csvstateData = censusAnalyser.LoadIndiaStateCode();
            Assert.AreEqual(37, csvstateData);
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void givenIndianStateCode_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NULL_PATH_NOT_ALLOW, e.type);
            }

        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianStateCode_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(WORNG_INDIA_STATE_CODE_PATH);
                censusAnalyser.LoadIndiaStateCode();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(WRONG_STATE_CODE_FILE_EXTENSION);
                censusAnalyser.LoadIndiaStateCode();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_STATE_CODE_PATH);
                censusAnalyser.LoadIndiaStateCode();
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
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_STATE_CODE_PATH);
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "state", 0);
                Assert.AreEqual("Andhra Pradesh", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }


        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "state", 28);
                Assert.AreEqual("West Bengal", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>

        [Test]
        public void givenIndianCensusData_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIAN_STATE_CENSUS_WRONG_JSON_PATH);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.WRONG_JSON_PATH, e.type);
            }

        }

        /// <summary>
        /// Load the INDIA STATE CODE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_STATE_CODE_PATH);
                censusAnalyser.LoadIndiaStateCode();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CODE_JSON_PATH, "state", 0);
                Assert.AreEqual("Andaman and Nicobar Islands", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the INDIA STATE CODE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            try 
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_STATE_CODE_PATH);
                censusAnalyser.LoadIndiaStateCode();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CODE_JSON_PATH, "state", 36);
                Assert.AreEqual("West Bengal", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }


        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "population", 0);
                Assert.AreEqual("607688", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLargetArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "areaInSqKm", 28);
                Assert.AreEqual("240928", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetSortedCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "population", 28);
                Assert.AreEqual("199812341", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the Indian Statem Code File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void givenUsCencusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                int csvstateData = censusAnalyser.LoadUsCencusData();
                Assert.AreEqual(51, csvstateData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void givenUsCencusData_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.NULL_PATH_NOT_ALLOW, e.type);
            }

        }

        /// <summary>
        /// Load the US CENCUS WRONG JSON PATH and Throw WRONG JS0N PATH Not Allow Exception
        /// </summary>
        [Test]
        public void givenUsCensusData_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENCUS_WRONG_JSON_PATH);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.WRONG_JSON_PATH, e.type);
            }

        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "population", 0);
                Assert.AreEqual("563626", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "population", 50);
                Assert.AreEqual("37253956", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnpopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "populationDencity", 0);
                Assert.AreEqual("0.46", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestpopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "populationDencity", 50);
                Assert.AreEqual("3805.61", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowesttotalArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "totalArea", 0);
                Assert.AreEqual("177", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighesttotalArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetSortedCensusData(US_CENCUS_JSON_PATH, "totalArea", 50);
                Assert.AreEqual("1723338.01", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnPopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(INDIA_CENSUS_CSV_FILE_PATH);
                censusAnalyser.LoadIndiaCensusData();
                string sortedData = censusAnalyser.GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(INDIAN_STATE_CENSUS_JSON_PATH, "dencityPerSqKm", 0);
                Assert.AreEqual("50", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void givenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnPopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(US_CENSUS_FILE_PATH);
                censusAnalyser.LoadUsCencusData();
                string sortedData = censusAnalyser.GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(US_CENCUS_JSON_PATH, "populationDencity", 0);
                Assert.AreEqual("36.45", sortedData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.type);
            }
        }

        

    }
}