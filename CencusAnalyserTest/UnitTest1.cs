// <copyright file="Tests.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserTest
{
    using System;
    using System.Data;
    using CencusAnalyserProgram;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;

    /// <summary>
    /// Tests Class
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string indiaStateCensusJsonPath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCensusData.JSON";
        
        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string indianStateCodeJsonPath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCode.JSON";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string usaCensusJsonPath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/UsCencusJsonFile.JSON";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string indianStateCensusWrongJsonPath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/indianStateCensus.JSON";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string usaCensusWrongJsonPath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/UsCencusJson.JSON";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string indiaCensusCsvFilePath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.csv";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string wrongCsvFilePath = @"./src/main/resources/IndiaStateCensusData.csv";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string wrongCsvFileExtension = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCensusData.pdf";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string indiaStateCodePath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCode.csv";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string wrongIndiaStateCodePath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/IndiaStateCode.csv";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string wrongStateCodeFileExtension = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/IndiaStateCode.jpg";

        /// <summary>
        /// Used string variables to store the file paths
        /// </summary>
        private static string usaFilePath = @"C:/Users/Vishal/source/repos/CencusAnalyserProgram/CencusAnalyserTest/Resources/USCensusData.csv";
       
        /// <summary>
        /// Load the Indian Census File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianCensusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);         
                int csvDatacount = censusAnalyser.LoadIndiaCensusData();
                Assert.AreEqual(29, csvDatacount);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);       
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the Empty Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenPassEmptyString_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(" ");       
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongPathName_shouldThrowCustomException() 
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongCsvFilePath);        
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file path with incorrect extension Type to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongCsvFileExtension);        
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndiaCensusData_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongCsvFileExtension);  
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData__WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath); 
                censusAnalyser.LoadIndiaCensusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.Type);
            }
        }

        /// <summary>
        /// Load the Indian State Code File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenIndianStateCode_CSVFile_ShouldReturnsCorrectRecords()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaStateCodePath);     
                int csvstateData = censusAnalyser.LoadIndiaStateCode();
                Assert.AreEqual(37, csvstateData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the Empty Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenIndiaStateCodeData_WhenPassEmptyString_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(" "); 
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);    
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongIndiaStateCodePath);  
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file path with incorrect extension Type to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongStateCodeFileExtension);
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndiaStateCode_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaStateCodePath);    
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMETER_INCORRECT_EXCEPTION, e.Type);
            }
        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianStateCode_WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaStateCodePath);      
                censusAnalyser.LoadIndiaStateCode();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);     
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "State", 0);
                Assert.AreEqual("Andhra Pradesh", sortedData[0]["State"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "State", 28);
                Assert.AreEqual("West Bengal", sortedData[28]["State"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Given incorrect file path to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenIndianCensusData_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indianStateCensusWrongJsonPath);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA STATE CODE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnFirstState()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaStateCodePath);
                censusAnalyser.LoadIndiaStateCode();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indianStateCodeJsonPath, "State", 0);
                Assert.AreEqual("Andaman and Nicobar Islands", sortedData[0]["State"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA STATE CODE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianStateCodeCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLastState()
        {
            try 
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaStateCodePath);
                censusAnalyser.LoadIndiaStateCode();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indianStateCodeJsonPath, "State", 36);
                Assert.AreEqual("West Bengal", sortedData[36]["State"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "Population", 0);
                Assert.AreEqual("607688", sortedData[0]["Population"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLargestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "Population", 28);
                Assert.AreEqual("199812341", sortedData[28]["Population"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnSmallestArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "AreaInSqKm", 0);
                Assert.AreEqual("3702", sortedData[0]["AreaInSqKm"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLargetArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(indiaStateCensusJsonPath, "AreaInSqKm", 28);
                Assert.AreEqual("342239", sortedData[28]["AreaInSqKm"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the Indian State Code File and Check For the number of records present in the file
        /// </summary>
        [Test]
        public void GivenUsCencusData_CSVFile_ShouldReturnsCorrectRecords()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                int csvstateData = censusAnalyser.LoadUsCencusData();
                Assert.AreEqual(51, csvstateData);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the Empty Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenUsCensusData_WhenPassEmptyString_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(" ");       
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Load the Null Parameter and Throw Null Path Not Allow Exception
        /// </summary>
        [Test]
        public void GivenUsCencusData_WhenPassNull_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(null);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENCUS WRONG JSON PATH and Throw WRONG JS0N PATH Not Allow Exception
        /// </summary>
        [Test]
        public void GivenUsCensusData_WhenWrongPathName_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaCensusWrongJsonPath);
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file path with incorrect extension Type to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUsCensusData_WhenWrongExtension_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongCsvFileExtension);       
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file with load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUsCensusData_WhenDelimeterIncorrect_shouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(wrongCsvFileExtension);  
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.UNEXPECTED_ERROR, e.Type);
            }
        }

        /// <summary>
        /// Given file with incorrect header to load the data should throw exception
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData__WhenIncorrectHeader_ShouldThrowCustomException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);  
                censusAnalyser.LoadUsCencusData();
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.HEADER_INCORRECT, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "Population", 0);
                Assert.AreEqual("563626", sortedData[0]["Population"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestPopulation()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "Population", 50);
                Assert.AreEqual("37253956", sortedData[50]["Population"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnpopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "PopulationDencity", 0);
                Assert.AreEqual("0.46", sortedData[0]["PopulationDencity"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighestpopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "PopulationDencity", 50);
                Assert.AreEqual("3805.61", sortedData[50]["PopulationDencity"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLowesttotalArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "TotalArea", 0);
                Assert.AreEqual("177", sortedData[0]["TotalArea"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnHighesttotalArea()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, "TotalArea", 50);
                Assert.AreEqual("1723338.01", sortedData[50]["TotalArea"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the INDIA CENSUS CSV FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenIndianCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnPopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(indiaCensusCsvFilePath);
                censusAnalyser.LoadIndiaCensusData();
                JArray sortedData = censusAnalyser.GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(indiaStateCensusJsonPath, "DencityPerSqKm", 0);
                Assert.AreEqual("50", sortedData[0]["DencityPerSqKm"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnLargestPopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(usaCensusJsonPath, "PopulationDencity", 0);
                Assert.AreEqual("36.45", sortedData[0]["PopulationDencity"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnSmallestPopulationDencity()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(usaCensusJsonPath, "PopulationDencity", 50);
                Assert.AreEqual("2.24", sortedData[50]["PopulationDencity"].ToString());
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, e.Type);
            }
        }

        /// <summary>
        /// Load the US CENSUS FILE PATH and Check Return Assumption of Given Index.
        /// </summary>
        [Test]
        public void GivenUsCensusCSVData_WhenSorting_WhenAnalyseCsvtoJson_ReturnThrowException()
        {
            try
            {
                CensusAnalyser censusAnalyser = new CensusAnalyser(usaFilePath);
                censusAnalyser.LoadUsCencusData();
                JArray sortedData = censusAnalyser.GetSortedCensusData(usaCensusJsonPath, " ", 50);
            }
            catch (CensusAnalyserException e)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INDEX_NOT_FOUND, e.Type);
            }
        }
    }
}