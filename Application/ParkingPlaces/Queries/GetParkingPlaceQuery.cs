using Application.Common.Interfaces;
using Application.ParkingPlaces.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ParkingPlaces.Queries
{
    public class GetParkingPlaceQuery : IRequest<ParkingPlaceDto>
    {
        public int Id { get; set; }

    }

    public class GetParkingPlaceQueryHandler : IRequestHandler<GetParkingPlaceQuery, ParkingPlaceDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetParkingPlaceQueryHandler(
            IApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ParkingPlaceDto> Handle(GetParkingPlaceQuery request, CancellationToken cancellationToken)
        {
            var parkingEntity = await _context
               .ParkingPlaces
               .ProjectTo<ParkingPlaceDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync(x => x.Id == request.Id);


            return parkingEntity;
        }
    }
}
