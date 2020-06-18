// <copyright file="CensusAnalyserException.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    ///  Class used to Define Custom Exceptions
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        /// <summary>
        /// declare Variable
        /// </summary>
        public ExceptionType Type;

        /// <summary>
        /// define variable
        /// </summary>
        private string message;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException" /> class
        /// This Method is Used to Load message And Exception Type
        /// </summary>
        /// <param name="message">assign message</param>
        /// <param name="type">assign exception type</param>
        public CensusAnalyserException(string message, ExceptionType type)
        {
            this.Type = type;
            this.message = message;
        }

        /// <summary>
        /// Enum is Used to define Enumerated Data types
        /// </summary>
        public enum ExceptionType
        {
            /// <summary>
            /// Define for CENSUS FILE PROBLEM
            /// </summary>
            CENSUS_FILE_PROBLEM,

            /// <summary>
            /// Define for CENSUS FILE WRONGE EXTENSION
            /// </summary>
            CENSUS_FILE_WRONGE_EXTENSION,

            /// <summary>
            /// Define for DELIMETER INCORRECT EXCEPTION
            /// </summary>
            DELIMETER_INCORRECT_EXCEPTION,

            /// <summary>
            /// Define for HEADER INCORRECT 
            /// </summary>
            HEADER_INCORRECT,

            /// <summary>
            /// Define for DATA NOT FOUND
            /// </summary>
            DATA_NOT_FOUND,

            /// <summary>
            /// Define for UNEXPECTED ERROR
            /// </summary>
            UNEXPECTED_ERROR,

            /// <summary>
            /// Define for NULL PATH NOT ALLOW
            /// </summary>
            NULL_PATH_NOT_ALLOW,

            /// <summary>
            /// Define for FILE NOT FOUND
            /// </summary>
            FILE_NOT_FOUND,

            /// <summary>
            /// Define for WRONG JSON PATH
            /// </summary>
            WRONG_JSON_PATH,

            /// <summary>
            /// Define for INDEX NOT FOUND
            /// </summary>
            INDEX_NOT_FOUND
        }
    }
}
