using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Enums
{
    public enum ProductClassificationEnum
    {
        [Description("Regular User")] Regular = 0,
        [Description("Gold User")] Gold = 1,
        [Description("Silver User")] Silver = 2,
        [Description("RoseGold User")] RoseGold = 3
    }
}
