using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{

    /// <summary>
    /// CensusAnalyserException Class used to Define Custom Exceptions
    /// </summary>

    public class CensusAnalyserException : Exception
    {
        public string message;

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>

        public enum ExceptionType
        {
            CENSUS_FILE_PROBLEM,
            CENSUS_FILE_WRONGE_EXTENSION,
            DELIMETER_INCORRECT_EXCEPTION,
            HEADER_INCORRECT,
            DATA_NOT_FOUND,
            NULL_PATH_NOT_ALLOW
        }

        public ExceptionType type;
       
 

        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
            this.message = message;
        }


    }
}
