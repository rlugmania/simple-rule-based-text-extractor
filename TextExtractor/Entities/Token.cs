using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Entities
{
    public class Token
    {
        public string Value { get; set; }
        public bool IsFuzzy { get; set; }

        public Token(string value, bool isFuzzy)
        {
            Value = value;
            IsFuzzy = isFuzzy;
        }
    }
}
