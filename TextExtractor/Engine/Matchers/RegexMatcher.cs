using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextExtractor.Engine.Matchers
{
    public class RegexMatcher: IMatcher
    {
        public Regex Regex { get; set; }

        public RegexMatcher(string pattern)
        {
            Regex = new Regex(pattern);
        }

        public string Match(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
