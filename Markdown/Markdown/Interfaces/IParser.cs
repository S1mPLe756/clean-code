using Markdown.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Interfaces
{
    internal interface IParser
    {
        public List<Token> Parse(string text);
    }
}
