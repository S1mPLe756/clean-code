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
    }
}