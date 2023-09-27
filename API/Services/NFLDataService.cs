using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class NFLDataService : INflDataService
    {
        private readonly IHtmlDocument _docService;

        public NFLDataService(IHtmlDocument docService)
        {
            _docService = docService;
        }

        public async Task<List<Player>> GetCurrentLeadingPlayers()
        {
            List<Player> _leaders = new();
            var link = "https://www.footballdb.com/index.html";
            var doc = _docService.GetDocument(link);

            //TODO: get player data.
            return _leaders;
        }
    }
}
