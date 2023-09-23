using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Matchup
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string? GameDate { get; set; }
        public Team? AwayTeam { get; set; }
        public Team? HomeTeam { get; set; }
    }
}
