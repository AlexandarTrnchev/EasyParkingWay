using EasyParkingWay.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Application.Payments.Models;
using Application.Payments.Command;
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

        [HttpPost]
        public async Task<IActionResult> Payment([FromForm]PaymentModel paymentModel)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var result = await Mediator.Send<bool>(new AddPaymentCommand { PaymentModel = paymentModel, UserId = userId });
            if (!result)
            {
                return View("Home");
            }

            return RedirectToAction("GetAllParkingPlacesByParkingId", "Home", new { parkingId = paymentModel.ParkingId, createPayment = true});
        }
    }
}
