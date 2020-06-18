// <copyright file="IndianCencusCSV.cs" company="BridgeLab">
//      Copyright (c) Company. All rights reserved.
// </copyright>
// <author>Vishal Waman</author>

namespace CencusAnalyserProgram
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Declare Variable with get and set method.
    /// </summary>
    public class IndianCencusCSV
    {
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
        public int AreaInSqKm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is active.
        /// </summary>
        public int DencityPerSqKm { get; set; }
    }
}
