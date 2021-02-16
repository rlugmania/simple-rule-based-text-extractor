using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextExtractor.Engine
{
    public class WordTokenizer : ITokenizer
    {
        char[] _tokens = new char[] { ' ', '\r', '\n' };

        public string[] GetWords(string text)
            => text.Split(_tokens, StringSplitOptions.RemoveEmptyEntries);

        public void RemoveTokens(params char[] tokens) => _tokens = (char[])_tokens.Except(tokens);

        public void AddTokens(params char[] tokens) => _tokens = (char[])_tokens.Union(tokens);

        public void ClearTokens(params char[] tokens) => _tokens = new char[0];
    }
}
