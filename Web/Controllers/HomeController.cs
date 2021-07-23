using EasyParkingWay.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Cities.Queries.GetAllCitiesQuery;
using Application.Cities.Queries.GetCityByIdQuery;
using Application.Parkings.Queries.GetallParkingsByCityIdQuery;
using Application.ParkingPlaces.Queries.GetAllParkingPlacesByParkingIdQuery;

namespace EasyParkingWay.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            
            object res = await Mediator.Send(new GetAllCitiesQuery());
            return View(res);
        }

        public async Task<IActionResult> GetCityById(int id)
        {

            object res = await Mediator.Send(new GetCityByIdQuery { Id = id});
            return View(res);
        }

        public async Task<IActionResult> GetAllParkingsByCityId(int cityId)
        {
            //ToDo:
            object res = await Mediator.Send(new GetAllParkingsByCityIdQuery { CityId = cityId});
            return View(res);
        }
        
        public async Task<IActionResult> GetAllParkingPlacesByParkingId(int parkingId)
        {
            object res = await Mediator.Send(new GetAllParkingPlacesByParkingIdQuery { ParkingId = parkingId});
            return View(res);
        }






        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
