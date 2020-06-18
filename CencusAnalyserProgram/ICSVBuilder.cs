// <copyright file="ICSVBuilder.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Text;

    /// <summary>
    /// Created Interface ICSVBuilder to LoadData Method Globally
    /// </summary>
    public interface ICSVBuilder
    {
        /// <summary>
        /// Declare DataTable variable
        /// </summary>
        /// <param name="path">String argument</param>
        /// <returns>Return DataTable Object</returns>
        public DataTable DataLoader(string path);

        /// <summary>
        /// Declare List Variable
        /// </summary>
        /// <param name="csvCensusData">DataTable Argument</param>
        /// <returns>Return List Object</returns>
        public List<CencusDAO> UsDataAssigned(DataTable csvCensusData);

        /// <summary>
        /// Declare List Variable
        /// </summary>
        /// <param name="csvCensusData">DataTable Argument</param>
        /// <returns>Return List Object</returns>
        public List<CencusDAO> IndianStateDataAssigned(DataTable csvCensusData);

        /// <summary>
        /// Declare List Variable
        /// </summary>
        /// <param name="csvCensusData">DataTable Argument</param>
        /// <returns>Return List Object</returns>
        public List<CencusDAO> CensusDataAssigned(DataTable csvCensusData);
    }
}
