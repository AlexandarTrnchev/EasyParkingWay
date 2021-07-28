using System.ComponentModel;

namespace Infrastructure.Enums
{
    public enum IdentityPolicyEnum
    {
        [Description("ReadPolicy")]
        ReadPolicy = 1,

        [Description("WritePolicy")]
        WritePolicy = 2
    }
}
