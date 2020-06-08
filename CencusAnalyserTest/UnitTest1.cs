using NUnit.Framework;
using CencusAnalyserProgram;
using System.Data;

namespace CencusAnalyserTest
{
    public class Tests
    {

        private static string INDIA_CENSUS_CSV_FILE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.csv";
        private static string WRONG_CSV_FILE_PATH = @"./src/main/resources/IndiaStateCensusData.csv";
        private static string WRONG_CSV_FILE_EXTENSION = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.pdf";
        private static string INDIA_STATE_CODE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCode.csv";


        CensusAnalyser censusAnalyser = new CensusAnalyser();

        [Test]
        public void givenIndianCensusData_CSVFile_ShouldReturnsCorrectRecords()
        {
           
                DataTable csvData = censusAnalyser.loadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
                Assert.AreEqual(29, csvData.Rows.Count);
            
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongPathName_shouldThrowCustomException() 
        {
            try
            {
                censusAnalyser.loadIndiaCensusData(WRONG_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM, e.type);
            }
            
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                censusAnalyser.loadIndiaCensusData(WRONG_CSV_FILE_EXTENSION);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_WRONGE_EXTENSION, e.type);
            }
        }

        [Test]
        public void givenIndiaCensusData_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                censusAnalyser.loadIndiaCensusData(WRONG_CSV_FILE_EXTENSION);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMETER_INCORRECT_EXCEPTION, e.type);
            }

        }

        [Test]
        public void givenIndianCensusCSVData__WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                censusAnalyser.loadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.type);
            }
        }

        [Test]
        public void givenIndianStateCode_CSVFile_ShouldReturnsCorrectRecords()
        {

            DataTable csvData = censusAnalyser.loadIndiaCensusData(INDIA_STATE_CODE_PATH);
            Assert.AreEqual(37, csvData.Rows.Count);

        }

    }
}