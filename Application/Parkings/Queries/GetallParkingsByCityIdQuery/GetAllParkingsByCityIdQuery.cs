using Application.Common.Interfaces;
using Application.Parkings.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Parkings.Queries.GetallParkingsByCityIdQuery
{

    public class GetAllParkingsByCityIdQuery : IRequest<ParkingDtoListModel>
    {
        public int CityId { get; set; }
    }

    public class GetAllParkingsByCityIdQueryHandler : IRequestHandler<GetAllParkingsByCityIdQuery, ParkingDtoListModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllParkingsByCityIdQueryHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ParkingDtoListModel> Handle(GetAllParkingsByCityIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context
               .Parkings
               .Where(x => x.CityId == request.CityId)
               .ProjectTo<ParkingDto>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .ToListAsync();

            return new ParkingDtoListModel { Parkings = entities};
        }
    }
}
