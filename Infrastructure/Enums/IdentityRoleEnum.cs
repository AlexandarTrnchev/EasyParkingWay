using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
