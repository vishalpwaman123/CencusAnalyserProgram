// <copyright file="UsCencusCSV.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Define class
    /// </summary>
    public class UsCencusCSV
    {
        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public string StateId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public int Population { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public double TotalArea { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public double PopulationDencity { get; set; }
    }
}