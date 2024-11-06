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
            var input = @"\_��� ���\_";
            var expected = "��� ���";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EscapeCharacter_Double_MustUseTag()
        {
            var input = @"\\_��� ��� ����� �������� �����\\_";
            var expected = "<em>��� ��� ����� �������� �����</em>";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Header_ShouldAsH1()
        {
            var input = "# ��������� __� _�������_ ���������__";
            var expected = "<h1> ��������� <strong>� <em>�������</em> ���������</strong> </h1>";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void UnderscoresInsideNumbers_ShouldAsUnderscores()
        {
            var input = "�������� ������ ������ c �������_12_3 �� ��������� ����������";
            var expected = "�������� ������ ������ c �������_12_3 �� ��������� ����������";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SingleInsideDouble_ShouldWork()
        {
            var input = "__text _text text_ text__";
            var expected = "<strong>text <em>text text</em> text</strong>";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void DoubleInsideSingle_ShouldntWork()
        {
            var input = "_text __text text__ text_";
            var expected = "_text __text text__ text_";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Intersection_ShouldntWork()
        {
            var input = "_text __text text_ text__";
            var expected = "_text __text text_ text__";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void InDifferentWords_ShouldntWork()
        {
            var input = "_text te_xt tex__t t_ext";
            var expected = "_text te_xt tex__t t_ext";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void UnpairedTags_ShouldntWork()
        {
            var input = "_text__";
            var expected = "_text__";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void EmptyString_ShouldAsEmpty()
        {
            var input = "____";
            var expected = "____";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AfterBeginningUndescore_ShouldNonBlankSymbol()
        {
            var input = "text_ text_";
            var expected = "text_ text_";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AfterEndingUndescore_ShouldNonBlankSymbol()
        {
            var input = "_text _text";
            var expected = "_text _text";

            string result = markdownProcessor.GetHtml(input);

            Assert.AreEqual(expected, result);
        }
    }
}