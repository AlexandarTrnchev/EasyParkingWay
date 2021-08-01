﻿using EasyParkingWay.Controllers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Application.Payments.Models;
using Application.Payments.Command;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Enums;
using Application.Payments.Queries.GetAllPaymentQuery;

namespace Web.Controllers
{
    [Authorize(Policy = nameof(IdentityPolicyEnum.ReadPolicy))]
    public class PaymentController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly ILogger<PaymentController> _logger;
        private UserManager<IdentityUser> _userManager;

        public PaymentController(ILogger<PaymentController> logger, UserManager<IdentityUser> userManager)
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
            paymentModel.UserName = HttpContext.User.Identity.Name;

            var result = await Mediator.Send<bool>(new AddPaymentCommand { PaymentModel = paymentModel, UserId = userId });
            if (!result)
            {
                return RedirectToAction("Index", "Home");
            }
            if (User.IsInRole(nameof(IdentityRoleEnum.Admin)))
            {
                return RedirectToAction("GetAllParkingPlacesByParkingId", "Admin", new { parkingId = paymentModel.ParkingId, createPayment = "success" });

            }

            return RedirectToAction("GetAllParkingPlacesByParkingId", "Home", new { parkingId = paymentModel.ParkingId, createPayment="success" });
        }

        public async Task<IActionResult> GetAllPayments()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var result = await Mediator.Send(new GetAllPaymentsQuery {UserId = userId });

            return View(result);
        }
    }
}
