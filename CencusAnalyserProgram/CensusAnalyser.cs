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
        public List<IndianCencusCSV> indiancensusList = new List<IndianCencusCSV>();
        public List<IndianStateCodeCSV> indiaStateCodeList = new List<IndianStateCodeCSV>();

        public int LoadIndiaCensusData(string path)
        {
            int row = 0;
            IndianCencusCSV indianCencusCsv = new IndianCencusCSV();
            ICSVBuilder csvBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = csvBuilder.DataLoader(path);

            while (row < csvCensusData.Rows.Count)
            {
                indianCencusCsv.areaInSqKm = Convert.ToInt32(csvCensusData.Rows[row]["AreaInSqKm"].ToString());
                indianCencusCsv.dencityPerSqKm = Convert.ToInt32(csvCensusData.Rows[row]["DensityPerSqKm"].ToString());
                indianCencusCsv.population = Convert.ToInt32(csvCensusData.Rows[row]["Population"].ToString());
                indianCencusCsv.state = csvCensusData.Rows[row]["State"].ToString();
                indiancensusList.Add(indianCencusCsv);
                row++;
            }
            return (indiancensusList.Count-29);
        }

        public int LoadIndiaStateCode(string path)
        {
            int row = 0;
            IndianStateCodeCSV indianStateCodeCsv = new IndianStateCodeCSV();
            ICSVBuilder cSVBuilder = CSVBuilderFactory.createOpenCsvBuilder();
            csvCensusData = cSVBuilder.DataLoader(path);
            while (row < csvCensusData.Rows.Count)
            {
                indianStateCodeCsv.srNo = Convert.ToInt32(csvCensusData.Rows[row]["SrNo"].ToString());
                indianStateCodeCsv.stateName = (csvCensusData.Rows[row]["State Name"].ToString());
                indianStateCodeCsv.tin = Convert.ToInt32(csvCensusData.Rows[row]["TIN"].ToString());
                indianStateCodeCsv.stateCode = csvCensusData.Rows[row]["StateCode"].ToString();
                indiaStateCodeList.Add(indianStateCodeCsv);
                row++;
            }
            return indiaStateCodeList.Count;
        }

    }
 }

