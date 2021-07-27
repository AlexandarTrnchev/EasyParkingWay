using EasyParkingWay.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Application.Payments.Models;
using Application.Payments.Command;
using System.Web;
using Microsoft.AspNetCore.Identity;

namespace Web.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly ILogger<HomeController> _logger;
        private UserManager<IdentityUser> _userManager;

        public PaymentController(ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index( PaymentModel paymentModel)
        {
            return View(paymentModel);
        }

        public async Task<IActionResult> Paymant(PaymentModel paymentModel)
        {
            //UserId = _userManager.GetUserId()
            object res = await Mediator.Send(new AddPaymentCommand { PaymentModel = paymentModel});
            return View(res);
        }
    }
}
