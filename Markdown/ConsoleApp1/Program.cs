using Markdown;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var markdownProcessor = new MdProcessor();
            var text = "__t_e_xt__";
            var result = markdownProcessor.GetHtml(text);
            Console.WriteLine(result);
        }
    }
}
