using System;
using System.Globalization;
using System.IO;

namespace CencusAnalyserProgram
{
    internal class CsvReader 
    {
        private StreamReader reader;
        private CultureInfo invariantCulture;

        public CsvReader(StreamReader reader, CultureInfo invariantCulture)
        {
            this.reader = reader;
            this.invariantCulture = invariantCulture;
        }

        internal object GetRecords<T>()
        {
            throw new NotImplementedException();
        }
    }
}