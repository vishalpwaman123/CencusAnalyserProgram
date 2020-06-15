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
            NULL_PATH_NOT_ALLOW,
            FILE_NOT_FOUND,
            WRONG_JSON_PATH
        }

        public ExceptionType type;

        /// <summary>
        /// This Method is Used to Load message And Exception Type
        /// </summary>
        /// <param name="path">path parameter contains the String And ExceptionType</param>
        /// <returns>It Not returns Anything</returns>
        public CensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
            this.message = message;
        }


    }
}
