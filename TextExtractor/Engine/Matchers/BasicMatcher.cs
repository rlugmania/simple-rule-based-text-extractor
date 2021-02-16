using System;
using System.Collections.Generic;
using System.Text;
using TextExtractor.Engine.Locators;

namespace TextExtractor.Engine.Matchers
{
    public class BasicMatcher : IMatcher
    {

        public string Match(string[] data)
        {
            if (data.Length> 0)
                return data[0];
            return null;
        }
    }
}
