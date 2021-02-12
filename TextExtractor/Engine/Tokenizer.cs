using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine
{
    internal class Tokenizer
    {
        string[] _tokens = new string[] { " ", "\r\n", "\r", "\n" };

        public string[] GetWords(string text) 
            => text.Split(_tokens, StringSplitOptions.RemoveEmptyEntries);
    }
}
