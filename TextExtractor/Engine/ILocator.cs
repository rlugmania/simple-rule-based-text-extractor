using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine
{
    public interface ILocator
    {
        string Name { get; set; }

        IEnumerable<string> TryExtraction(string [] data);
    }
}
