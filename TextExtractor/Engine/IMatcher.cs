using System;
using System.Collections.Generic;
using System.Text;

namespace TextExtractor.Engine
{
    public interface IMatcher
    {
        string Match(string[] data);
    }
}
