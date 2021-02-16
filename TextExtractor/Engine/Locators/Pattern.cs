using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine.Locators
{
    public class Pattern : BaseLocator, ILocator
    {
        public override IEnumerable<string> TryExtraction(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
