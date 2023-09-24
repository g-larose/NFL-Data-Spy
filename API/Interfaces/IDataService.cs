using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDataService
    {
        public List<string> LoadTeamNames();
        public string GetEnumDescription(Enum value);
    }
}
