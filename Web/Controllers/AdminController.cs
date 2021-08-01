using Infrastructure.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Application.Payments.Queries.GetAllPaymentQuery;
using System;
using Application.ParkingPlaces.Queries.GetAllParkingPlacesByParkingIdQuery;
using Application.Parkings.Models;
using Application.Parkings.Commands;
using Application.ParkingPlaces.Queries;
using Application.ParkingPlaces.Models;
using Application.ParkingPlaces.Commands;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Application.Cities.Queries.GetAllCitiesQuery;

namespace Web.Controllers
{
    [Authorize(Policy = nameof(IdentityPolicyEnum.WritePolicy))]
    public class AdminController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly ILogger<AdminController> _logger;
        private UserManager<IdentityUser> _userManager;

        public AdminController(ILogger<AdminController> logger, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
        }
        public async Task<IActionResult> GetAllPayments(int? paymentId)
        {
            var result = await Mediator.Send(new GetAllPaymentsQuery { Id = paymentId });

            return View(result);
        }

        public async Task<IActionResult> GetAllParkingPlacesByParkingId(int parkingId, DateTime? from, DateTime? to)
        {
            object res = await Mediator.Send(new GetAllParkingPlacesByParkingIdQuery { ParkingId = parkingId, From = from, To = to });
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> EditParking(int parkingId, ParkingEditDto data)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("\\");
            }
            int res = await Mediator.Send(new EditParkingCommand { Id = parkingId, ParkingEditData = data });

            return RedirectToAction("GetAllParkingPlacesByParkingId", "Admin", new { parkingId = res});
        }

        //Not Use
        public async Task<IActionResult> GetParkingPlace (int id )
        {
            object res = await Mediator.Send(new GetParkingPlaceQuery { Id = id });
            return View(res);
        }

        [HttpPost]
        public async Task<IActionResult> EditParkingPlace(EditParkingPlaceModel data)
        {
            int res = await Mediator.Send(new EditParkingPlaceCommand { Data = data });

            return  RedirectToAction("GetAllParkingPlacesByParkingId", "Admin", new { parkingId = data.ParkingId });
        }

        [HttpGet]
        public async Task<IActionResult> AddParking()
        {
            var cities = await Mediator.Send(new GetAllCitiesQuery());
            ViewData["Cities"] = cities;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddParking(AddParkingModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }
            
            int newParkingId = await Mediator.Send(new AddParkingCommand { Data = data});


            return RedirectToAction("GetAllParkingPlacesByParkingId", "Admin", new { parkingId = newParkingId });
        }
        
    }
}
