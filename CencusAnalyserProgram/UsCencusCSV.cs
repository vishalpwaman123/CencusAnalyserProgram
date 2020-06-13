using System;
using System.Collections.Generic;
using System.Text;

namespace CencusAnalyserProgram
{
    //State_Id	State	Population	Housing_units	Total_area	Water_area	Land_area	Population_Density	Housing_Density

    public class UsCencusCSV
    {
        public string stateId { get; set; }
        public string state { get; set; }
        public Int32 population { get; set; }
        public double totalArea { get; set; }
        public double populationDencity { get; set; }

    }
}
