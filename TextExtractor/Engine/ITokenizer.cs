using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine
{
    public interface ITokenizer
    {
        string[] GetWords(string text);
    }
}
