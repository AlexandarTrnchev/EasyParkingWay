using System.ComponentModel;

namespace Infrastructure.Enums
{
    public enum IdentityRoleEnum
    {
        [Description("Admin")]
        Admin = 1,

        [Description("User")]
        User = 2
    }
}
