using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Services
{
    public class DataService : IDataService
    {
        public List<string> LoadTeamNames()
        {
            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Json", "team_names.json"));
            var names = JsonSerializer.Deserialize<List<TeamNames>>(json).Select(x => x.Name).ToList();

            return names;

        }
    }
}
