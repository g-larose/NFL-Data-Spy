using API.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class HtmlDocumentService : IHtmlDocument
    {
        /// <summary>
        /// Get Html Document
        /// </summary>
        /// <param name="link"></param>
        /// <returns>HtmlDocument</returns>
        #region GET HTMLDOCUMENT
        public HtmlDocument GetDocument(string link)
        {
            var web = new HtmlWeb();
            var doc = web.Load(link);

            return doc;
        }

        #endregion

        /// <summary>
        /// Gets a specific HtmlNode
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="name"></param>
        /// <returns>HtmlNode</returns>
        #region GETNODE
        public HtmlNode GetNode(HtmlDocument doc, string name)
        {
            HtmlNode? node = doc.DocumentNode.SelectSingleNode(name);
            return node;
        }

        #endregion
    }
}
