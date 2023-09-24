using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public enum Division
    {
       [Description("AFC EAST")]
       AFC_EAST,
       [Description("AFC NORTH")]
       AFC_NORTH,
       [Description("AFC WEST")]
       AFC_WEST,
       [Description("AFC SOUTH")]
       AFC_SOUTH,
       [Description("NFC EAST")]
       NFC_EAST,
       [Description("NFC NORTH")]
       NFC_NORTH,
       [Description("NFC SOUTH")]
       NFC_SOUTH,
       [Description("NFC WEST")]
       NFC_WEST,
       [Description("UNKNOWN")]
       UNKNOWN,
    }
}
