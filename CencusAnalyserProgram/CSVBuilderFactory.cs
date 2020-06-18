// <copyright file="CSVBuilderFactory.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Declare class
    /// </summary>
    public class CSVBuilderFactory
    {
        /// <summary>
        /// This Class is created to remove the relation of Census with Load Data 
        /// </summary>
        /// <returns>It returns the object of Class</returns>
        public static ICSVBuilder CreateOpenCsvBuilder()
        {
            return new OpenCSVBuilder();
        }
    }
}
