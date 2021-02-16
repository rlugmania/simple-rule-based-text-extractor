using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextExtractor.Engine.Locators;

namespace TextExtractor.Engine
{


    public class Pipeline
    {
        public ITokenizer Tokenizer { get; }
        ILocator[] _extractionRules;

        public Pipeline(string model)
        {
            Tokenizer = new WordTokenizer();
            _extractionRules = RulesBuilder.GetRules(model).ToArray();
        }

        public Dictionary<string, IEnumerable<string>> Extract(string text)
        {
            var response = new Dictionary<string, IEnumerable<string>>();
            var words = Tokenizer.GetWords(text);
            // TODO Pass extraction model to a configuration Pipeline object
            var numberOfRules = _extractionRules.Count();
            for (int i = 0; i < numberOfRules; i++)
            {
                response.Add(_extractionRules[i].Name, _extractionRules[i].TryExtraction(words));
            }
            return response;
        }

        public bool Match()
        {
            return true;
        }
    }
}
