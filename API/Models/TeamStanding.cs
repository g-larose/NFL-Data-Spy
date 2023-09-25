using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class TeamStanding
    {
        public int Id { get; set; }
        public string? Teamname { get; set; }
        public string? Division { get; set; }
        public string? Wins { get; set; }
        public string? Losses { get; set; }
        public string? Ties { get; set; }

    }
}
