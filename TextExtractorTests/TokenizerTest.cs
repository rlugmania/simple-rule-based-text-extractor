using NUnit.Framework;
using TextExtractor.Engine;

namespace TextExtractorTests
{
    public class TokenizerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var data = @"PID: 234234234         PPOD : dgagdjgasdasdgjad
                         ABC asdads daddfas----------------------------";
            var tokenizer = new WordTokenizer();
            var words = tokenizer.GetWords(data);
            TestContext.Out.WriteLine(string.Join(",", words));

            Assert.AreEqual(words.Length, 8);
        }


    }
}