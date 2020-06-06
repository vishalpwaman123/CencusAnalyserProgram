using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            CENSUS_FILE_PROBLEM,
            CENSUS_FILE_WRONGE_EXTENSION
        }

        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }


    }
}
