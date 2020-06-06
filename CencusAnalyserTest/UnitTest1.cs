using NUnit.Framework;
using CencusAnalyserProgram;
using System.Data;

namespace CencusAnalyserTest
{
    public class Tests
    {

        private static string INDIA_CENSUS_CSV_FILE_PATH = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.csv";
        private static  string WRONG_CSV_FILE_PATH = @"./src/main/resources/IndiaStateCensusData.csv";


        [Test]
        public void givenIndianCensusData_CSVFile_ShouldReturnsCorrectRecords()
        {
           
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                DataTable csvData = censusAnalyser.loadIndiaCensusData(INDIA_CENSUS_CSV_FILE_PATH);
                Assert.AreEqual(29, csvData.Rows.Count);
            
        }

        [Test]
        public void givenIndiaCensusData_WhenWrongPathName_shouldThrowCustomException() 
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser();
                censusAnalyser.loadIndiaCensusData(WRONG_CSV_FILE_PATH);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.CENSUS_FILE_PROBLEM, e.type);
            }
            
        }

    }
}