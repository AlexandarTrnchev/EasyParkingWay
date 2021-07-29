using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Authorize(Policy = nameof(IdentityPolicyEnum.WritePolicy))]
    public class AdminController : Controller
    {
    }
}
