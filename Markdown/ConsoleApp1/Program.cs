using Markdown;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var markdownProcessor = new MdProcessor();
            var text = "_t __t__ t_\n_t __t t__ t_";
            var result = markdownProcessor.GetHtml(text);
            Console.WriteLine(result);
        }
    }
}
