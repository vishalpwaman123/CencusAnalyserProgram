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
    }
}
