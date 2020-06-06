using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            CENSUS_FILE_PROBLEM
        }

        ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }


    }
}
