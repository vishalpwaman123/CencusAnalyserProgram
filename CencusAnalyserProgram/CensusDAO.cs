using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    public class CensusDAO
    {

        public String state;
        public int population;
        public int densityPerSqKm;
        public int areaInSqKm;
        public int totalArea;
        public int populationDensity;
        public int srNo;
        public int tin;
        public string statecode;


        public CensusDAO(IndianCencusCSV indiaCensusCSV)
        {
            state = indiaCensusCSV.state;
            areaInSqKm = indiaCensusCSV.areaInSqKm;
            populationDensity = indiaCensusCSV.dencityPerSqKm;
            population = indiaCensusCSV.population;
        }

       /* public CensusDAO(IndianStateCodeCSV indianStateCodeCSV)
        {
            state = indianStateCodeCSV.state;
            srNo = indianStateCodeCSV.srNo;
            tin = indianStateCodeCSV.tin;
            statecode = indianStateCodeCSV.stateCode;
        }*/

    }
}
