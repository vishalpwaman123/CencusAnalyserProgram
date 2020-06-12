using System;
using System.Text;

namespace CencusAnalyserProgram
{
    internal class ChoJSONWriter : IDisposable
    {
        private StringBuilder sb;

        public ChoJSONWriter(StringBuilder sb)
        {
            this.sb = sb;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}