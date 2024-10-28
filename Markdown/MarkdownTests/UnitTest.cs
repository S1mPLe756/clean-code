using Markdown;

namespace MarkdownTests
{
    public class Tests
    {
        private readonly MdProcessor markdownProcessor;

        public Tests()
        {
            markdownProcessor = new MdProcessor();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var input = "_text_\n_text_";
            var expected = "<em>text</em>\n<em>text</em>";
            string result = markdownProcessor.GetHtml(input);
            Assert.AreEqual(expected, result);
        }
    }
}