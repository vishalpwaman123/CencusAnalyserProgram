using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    public class CSVBuilderFactory
    {
        /// <summary>
        /// This Class is created to remove the relation of Cevnsus analyser with LoadCsvData 
        /// </summary>
        /// <returns>It returns the object of OpencsvBuilder Class</returns>

        public static ICSVBuilder createOpenCsvBuilder()
        {
            return new OpenCSVBuilder();
        }
    }
}
