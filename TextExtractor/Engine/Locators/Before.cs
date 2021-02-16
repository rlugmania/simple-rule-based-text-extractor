using System;
using System.Collections.Generic;
using System.Text;
using TextExtractor.Entities;

namespace TextExtractor.Engine.Locators
{
    internal class Before: BaseLocator
    {
        public Token Token { get; set; }

        public override IEnumerable<string> TryExtraction(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
