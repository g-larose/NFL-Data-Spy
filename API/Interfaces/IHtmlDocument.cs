using HtmlAgilityPack;

namespace API.Interfaces;

public interface IHtmlDocument
{
    HtmlDocument GetDocument(string link);
    HtmlNode GetNode(HtmlDocument doc, string name);
}
