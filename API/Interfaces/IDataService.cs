using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDataService
    {
        List<string> LoadTeamNames();
        List<int> LoadSeasons();
        List<int> LoadWeeks();
        string GetEnumDescription(Enum value);
    }
}
