using Markdown;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var markdownProcessor = new MdProcessor();
            var text = "_text_";
            var result = markdownProcessor.GetHtml(text);
            Console.WriteLine(result);
        }
    }
}
