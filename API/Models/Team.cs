using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public Guid Identifier { get; set; }
        public string Name { get; set; }     = string.Empty;
        public string Abbr { get; set; }     = string.Empty;
        public string Record { get; set; }   = string.Empty;
        public string LogoUri { get; set; }  = string.Empty;
        public string Division { get; set; } = string.Empty;
        public List<Player>? Players { get; set; }
    }
}
