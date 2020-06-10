using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    public class CSVBuilderFactory
    {
        public static ICSVBuilder createOpenCsvBuilder()
        {
            return new OpenCSVBuilder();
        }
    }
}
