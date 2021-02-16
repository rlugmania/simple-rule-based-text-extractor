using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine.Locators
{

    public abstract class BaseLocator : ILocator
    {
        public string Name { get; set; }
        public IMatcher MatchingConditions { get; set; }

        public abstract IEnumerable<string> TryExtraction(string[] data);
        
    }
}
