using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextExtractor.Engine;
using TextExtractorTests.Utils;

namespace TextExtractorTests
{
    public class PipelineTest
    {
        string afterConfig;
        string data;

        [SetUp]
        public void Setup()
        {
            afterConfig = @"
[{
    ""Name"": ""FirstValue"",
    ""Location"": {
                ""Type"": ""After"",
        ""Token"": {
                    ""Value"": ""RTP:"",
            ""Fuzzy"": false
        },
        ""Match"": 
            {
                    ""Type"": ""Any""
            }
        
    }
}]";

            data = @"PID: 234234234         PPOD : dgagdjgasdasdgjad
                         ABC asdads daddfas---------------------------- RTP: asdasd";
        }

        [Test]
        public void SimpleAfterSchemaPipelineTest()
        {
            var pipeline = new Pipeline(afterConfig);
            Assert.IsNotNull(pipeline);
        }

        [Test]
        public void AfterLocatorTest()
        {
            var pipeline = new Pipeline(afterConfig);
            var response = pipeline.Extract(data);
            
            Assert.IsTrue(response.Count > 0);
            //TestContext.Out.WriteLine($"Extraction Response: {DebugExtensions.ToDebugString(response)}");
        }

        [Test]
        public void RegexLocatorTest()
        {
            var response = string.Empty;
            var match = Regex.Match(data, "RTP:((?=).*)?", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                response = match.Value;
            }
            Assert.IsTrue(response.Length > 0);
            //TestContext.Out.WriteLine($"Extraction Response: { response }");
        }
    }
}
