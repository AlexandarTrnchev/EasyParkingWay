using Application.Common.Interfaces;
using Application.ParkingPlaces.Models;
using Application.Parkings.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ParkingPlaces.Queries.GetAllParkingPlacesByParkingIdQuery
{
    public class GetAllParkingPlacesByParkingIdQuery : IRequest<ParkingPlaceDtoListModel>
    {
        public int ParkingId { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

    }

    public class GetAllParkingPlacesByParkingIdQueryHandler : IRequestHandler<GetAllParkingPlacesByParkingIdQuery, ParkingPlaceDtoListModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllParkingPlacesByParkingIdQueryHandler(
            IApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ParkingPlaceDtoListModel> Handle(GetAllParkingPlacesByParkingIdQuery request, CancellationToken cancellationToken)
        {
            var parkingEntity = await _context
               .Parkings
               .Include(pp => pp.ParkingPlaces)
               .ThenInclude(p => p.Payments)
               .Include(x => x.City)
               .FirstOrDefaultAsync(x => x.Id == request.ParkingId);

            var parking = _mapper.Map<ParkingDto>(parkingEntity);

            var places = parkingEntity
                .ParkingPlaces
                .AsQueryable()
                .ProjectTo<ParkingPlaceDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Number)
                .ToList();

            DateTime date1 = (request.From == null || request.From < DateTime.Now.Date) ? DateTime.Now.Date : (DateTime)request.From;
            DateTime date2 = (request.To == null || request.To < DateTime.Now.Date) ? DateTime.Now.Date : (DateTime)request.To;

            var dates = new List<DateTime> { date1, date2 }.OrderBy(x => x).ToList();

            foreach (var item in places)
            {
                if (item.Payments.Any(x => IsFreeForPeriod(x, dates[0].Date, dates[1].Date)))
                {
                    item.IsFree = false;
                }
                else
                {
                    item.IsFree = true;
                }
            }

            return new ParkingPlaceDtoListModel 
            { 
                ParkingPlaces = places, 
                Parking = parking,
                From = dates[0],
                To = dates[1],
            };
        }

        private bool IsFreeForPeriod(Payment payment, DateTime requestFrom, DateTime requestTo)
        {
            return (requestFrom.Date >= payment.RentFrom.Value.Date && requestFrom.Date <= payment.RentTo.Value.Date) || (requestTo.Date >= payment.RentFrom.Value.Date && requestTo.Date <= payment.RentTo.Value.Date);
        }
    }
}
