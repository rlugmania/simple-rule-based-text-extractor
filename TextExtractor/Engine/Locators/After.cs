using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextExtractor.Entities;

namespace TextExtractor.Engine.Locators
{
    internal class After : BaseLocator
    {
        public int Ratio { get; set; }
        public Token Token { get; set; }
        public int MatchNTokensAfter { get; set; }

        public After()
        {
            MatchNTokensAfter = 1;
            Ratio = 90;
        }

        public override IEnumerable<string> TryExtraction(string[] data)
        {
            var result = new List<string>();
            var comparativeValue = Token.Value;
            Predicate<string> matchPredicate = element => element == comparativeValue;
            if (Token.IsFuzzy)
                matchPredicate = element => Fuzz.Ratio(element, comparativeValue) > Ratio;

            var matchValue = Array.FindIndex(data, matchPredicate);
            if (matchValue > -1)
                return new string[] { MatchingConditions.Match(data.Skip(matchValue + 1).ToArray()) };
            else
                return null;

        }

    }
}
