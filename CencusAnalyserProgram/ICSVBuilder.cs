using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CencusAnalyserProgram
{


    /// <summary>
    /// Created Interface IcsvBuilder to accsess LoadData Method Globally
    /// </summary>
    public interface ICSVBuilder
    {
        public DataTable DataLoader(string path);
        public List<CencusDAO> UsDataAssigned(DataTable csvCensusData);
        public List<CencusDAO> IndianStateDataAssigned(DataTable csvCensusData);
        public List<CencusDAO> CensusDataAssigned(DataTable csvCensusData);
    }
}
