using System.ComponentModel;

namespace ProductManagementDomain.Models.Enum
{
    public enum EnumType
    {

        [Description("Regular User ")] Regular = 0,
        [Description("Gold User")] Gold = 1,
        [Description("Silver User ")] Silver = 2,
        [Description("RoseGold User ")] RoseGold = 3

    }

}
