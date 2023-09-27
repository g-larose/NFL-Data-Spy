using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string TeamName { get; set; }   = string.Empty;
        public List<(string year, string stat)>? Stats { get; set; }

    }
}
