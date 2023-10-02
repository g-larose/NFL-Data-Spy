using API.Interfaces;
using API.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Services
{
    public class DataService : IDataService
    {
        public string GetEnumDescription(Enum value)
        {
            System.Reflection.MemberInfo[] memInfo = value.GetType().GetMember(value.ToString());
            DescriptionAttribute? attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(memInfo[0]);
            return attribute!.Description;
        }

        public List<string> LoadTeamNames()
        {
            var json = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Json", "team_names.json"));
            var names = JsonSerializer.Deserialize<List<TeamNames>>(json)?.Select(x => x.Name).ToList();

            return names!;

        }

        public string GetConnectionString()
        {
            var jsonFile = File.ReadAllText("appsettings.json");
            var json = JsonSerializer.Deserialize<SettingsJson>(jsonFile);

            return json!.ConnectionString;
        }

        public List<int> LoadSeasons()
        {
            return Enumerable.Range(1970, 54).Reverse().ToList();
        }

        public List<int> LoadWeeks()
        {
            return Enumerable.Range(1, 17).ToList();
        }
    }
}
