using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CencusAnalyserProgram
{
    public interface ICSVBuilder
    {
        public DataTable DataLoader(string path);
    }
}
