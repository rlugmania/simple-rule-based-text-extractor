using System;
using System.Collections.Generic;
using System.Text;
using TextExtractor.Entities;

namespace TextExtractor.Engine.Locators
{
    internal class Between: BaseLocator
    {
        public Token StartToken { get; set; }
        public Token EndToken { get; set; }

        public override IEnumerable<string> TryExtraction(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
