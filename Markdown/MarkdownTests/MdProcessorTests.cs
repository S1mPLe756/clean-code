using Markdown;
using System.ComponentModel;

namespace MarkdownTests
{
    public class Tests
    {
        private MdProcessor markdownProcessor;

        [SetUp]
        public void Setup()
        {
            markdownProcessor = new MdProcessor();
        }

        [Test]
        public void Italic_SingleUnderscore_ShouldAsEm()
        {
            var input = "_text text_";
            var expected = "<em>text text</em>";

            string result = markdownProcessor.GetHtml(input);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Bold_DoubleUnderscore_ShouldAsStrong()
        {
            var input = "__text text__";
            var expected = "<strong>text text</strong>";
            
            string result = markdownProcessor.GetHtml(input);
            
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EscapeCharacter_Single_NotUseTag()
        {
            var input = @"\_Вот это\_";
            var expected = "Вот это";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EscapeCharacter_Double_MustUseTag()
        {
            var input = @"\\_вот это будет выделено тегом\\_";
            var expected = "<em>вот это будет выделено тегом</em>";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Header_ShouldAsH1()
        {
            var input = "# Заголовок __с _разными_ символами__";
            var expected = "<h1> Заголовок <strong>с <em>разными</em> символами</strong> </h1>";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void UnderscoresInsideNumbers_ShouldAsUnderscores()
        {
            var input = "Подчерки внутри текста c цифрами_12_3 не считаются выделением";
            var expected = "Подчерки внутри текста c цифрами_12_3 не считаются выделением";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }
    }
}