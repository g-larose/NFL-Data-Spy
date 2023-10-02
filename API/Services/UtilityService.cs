using API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class UtilityService : IUtility
    {

        /// <summary>
        /// Gets the first index of a char in a given string
        /// </summary>
        /// <param name="args"></param>
        /// <returns>int</returns>
        #region GET INDEX FROM STRING
        public int GetIndexFromString(string str, string ch)
        {
            return str.LastIndexOf(ch);
        }

        #endregion
    }
}
