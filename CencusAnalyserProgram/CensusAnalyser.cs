﻿// <copyright file="CensusAnalyser.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using CencusAnalyserProgram;
    using Microsoft.VisualBasic.FileIO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// define Class
    /// </summary>
    public class CensusAnalyser : Exception
    {
        /// <summary>
        /// List declaration
        /// </summary>
        private List<CencusDAO> cencusList = new List<CencusDAO>();

        /// <summary>
        /// Dictionary declaration
        /// </summary>
        private Dictionary<string, CencusDAO> dictionaryCensus = new Dictionary<string, CencusDAO>();

        /// <summary>
        /// DataTable declaration
        /// </summary>
        private DataTable csvCensusData = new DataTable();

        /// <summary>
        /// ICSVBuilder declaration
        /// </summary>
        private ICSVBuilder csvBuilder = CSVBuilderFactory.CreateOpenCsvBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyser" /> class
        /// This Method takes the input path of File and give to the LoadData Method Constructor
        /// </summary>
        /// <param name="path">path parameter contains the path of File</param>
        /// <returns>It returns the LoadedData in DataTable format</returns>
        public CensusAnalyser(string path)
        {
                this.csvCensusData = this.csvBuilder.DataLoader(path);
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the CensusDataAssigned Method 
        /// </summary>
        /// <returns>It returns the CensusDataAssigned in List format and return ConvertListToDictionary in Integer</returns>
        public int LoadIndiaCensusData()
        {
            try
            {
                this.cencusList = this.csvBuilder.CensusDataAssigned(this.csvCensusData);
                return this.ConvertListToDictionary(this.cencusList);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the IndianStateDataAssigned Method 
        /// </summary>
        /// <returns>It returns the IndianStateDataAssigned in List format and return ConvertListToDictionary in Integer</returns>
        public int LoadIndiaStateCode()
        {
            try
            {
                this.cencusList = this.csvBuilder.IndianStateDataAssigned(this.csvCensusData);
                return this.ConvertListToDictionary(this.cencusList);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
        }

        /// <summary>
        /// This Method takes the DataTable input and give to the UsDataAssigned Method 
        /// </summary>
        /// <returns>It returns the UsDataAssigned in List format and return ConvertListToDictionary in Integer</returns>
        public int LoadUsCencusData()
        {
            try
            {
                this.cencusList = this.csvBuilder.UsDataAssigned(this.csvCensusData);
                return this.ConvertListToDictionary(this.cencusList);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
        }

        /// <summary>
        /// This Method takes the input 
        /// </summary>
        /// <param name="dictionaryCensus">Passing dictionary argument</param>
        /// <returns>It returns the dictionaryCensus in boolean Format Or Exception Throws</returns>
        public bool EmptyDictionary(Dictionary<string, CencusDAO> dictionaryCensus)
        {
            if (dictionaryCensus == null || dictionaryCensus.Count() == 0)
            {
                throw new CensusAnalyserException("No Census Data Found", CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            }

            return true;
        }

        /// <summary>
        /// This Method takes the File path, key, index input 
        /// </summary>
        /// <param name="jsonFilepath">File Path</param>
        /// <param name="key">Header Name</param>
        /// <param name="index">Row Number</param>
        /// <returns>It returns the fetch Data OnKey in integer Format</returns>
        public JArray GetpopulationDencityWiseSortedUsCensusDataAndIndianStateCensusData(string jsonFilepath, string key, int index)
        {
            this.EmptyDictionary(this.dictionaryCensus);
            object listAlphabetically = this.cencusList.OrderBy(x => x.DencityPerSqKm);
            var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
            File.WriteAllText(jsonFilepath, dataInJsonFormat);
            return this.RetriveDataOnKey(jsonFilepath, key, index);
        }

        /// <summary>
        /// This Method takes the File path, key, index input 
        /// </summary>
        /// <param name="jsonFilepath">File Path</param>
        /// <param name="key">Header Name</param>
        /// <param name="index">Row Number</param>
        /// <returns>It returns the fetch Data OnKey in integer Format</returns>
        public JArray GetSortedCensusData(string jsonFilepath, string key, int index)
        {
            object listAlphabetically= null;
            try
            {
                this.EmptyDictionary(this.dictionaryCensus);
                switch (key)
                {
                    case "State":
                        listAlphabetically = this.cencusList.OrderBy(x => x.State);
                        break;

                    case "TotalArea":
                        listAlphabetically = this.cencusList.OrderBy(x => x.TotalArea);
                        break;

                    case "PopulationDencity":
                        listAlphabetically = this.cencusList.OrderBy(x => x.PopulationDencity);
                        break;

                    case "DencityPerSqKm":
                        listAlphabetically = this.cencusList.OrderBy(x => x.DencityPerSqKm);
                        break;

                    case "Population":
                        listAlphabetically = this.cencusList.OrderBy(x => x.Population);
                        break;

                    case "AreaInSqKm":
                        listAlphabetically = this.cencusList.OrderBy(x => x.AreaInSqKm);
                        break;

                    default :
                        throw new CensusAnalyserException("No Header found", CensusAnalyserException.ExceptionType.INDEX_NOT_FOUND);
                }
                var dataInJsonFormat = JsonConvert.SerializeObject(listAlphabetically, Formatting.Indented);
                File.WriteAllText(jsonFilepath, dataInJsonFormat);
                return this.RetriveDataOnKey(jsonFilepath, key, index);
            }
            catch (FileNotFoundException e)
            {
                throw new CensusAnalyserException(e.Message, CensusAnalyserException.ExceptionType.DATA_NOT_FOUND);
            }
        }

        /// <summary>
        /// This Method takes the List input
        /// </summary>
        /// <param name="cencusList">path parameter contains the List</param>
        /// <returns>It returns the dictionaryCensus in Integer Format</returns>
        private int ConvertListToDictionary(List<CencusDAO> cencusList)
        {
            this.dictionaryCensus = cencusList.ToDictionary(x => x.State);
            return this.dictionaryCensus.Count();
        }

        /// <summary>
        /// This Method takes the File path, key, index input 
        /// </summary>
        /// <param name="jsonPath">file path</param>
        /// <param name="key">Header name</param>
        /// <param name="index">row number</param>
        /// <returns>It returns the fetch Data On Key in integer Format</returns>        
        private JArray RetriveDataOnKey(string jsonPath, string key, int index)
        {
            string jsonfile = File.ReadAllText(jsonPath);
            JArray array = JArray.Parse(jsonfile);
            return array;
        }
    }
 }
