using Application.Common.Interfaces;
using Application.ParkingPlaces.Models;
using Application.Parkings.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
               .Include(x => x.ParkingPlaces)
               .Include(x => x.City)
               .FirstOrDefaultAsync(x => x.Id == request.ParkingId);

            var parking = _mapper.Map<ParkingDto>(parkingEntity);

            var places = parkingEntity
                .ParkingPlaces
                .AsQueryable()
                .ProjectTo<ParkingPlaceDto>(_mapper.ConfigurationProvider)
                .OrderBy(x => x.Number)
                .ToList();


            return new ParkingPlaceDtoListModel { ParkingPlaces = places , Parking = parking };
        }

        //private LinkedList<ParkingPlaceDto> IsFreeForPeriod(LinkedList<ParkingPlaceDto> listData, DateTime? from, DateTime? to)
        //{
            
        //}
    }
}
