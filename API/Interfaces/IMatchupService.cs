using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IMatchupService
    {
        HtmlDocument GetDocument(string link);
        HtmlNode GetNode(HtmlDocument doc, string name);
    }
}
