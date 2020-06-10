using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CencusAnalyserProgram;

namespace CencusAnalyserProgram
{
    public class CensusAnalyser : Exception
    {
        DataTable csvCensusData = new DataTable();

        public DataTable LoadIndiaCensusData(string path)
        {
            
            ICSVBuilder csvBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = csvBuilder.DataLoader(path);
            return csvCensusData;
        }

        public DataTable LoadIndiaStateCode(string path)
        {
            ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = cSVBuilder.DataLoader(path);
            return csvCensusData;
        }

    }
 }

