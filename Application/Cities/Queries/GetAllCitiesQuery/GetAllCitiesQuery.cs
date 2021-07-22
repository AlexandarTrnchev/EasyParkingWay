using Application.Cities.Models;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cities.Queries.GetAllCitiesQuery
{
    public class GetAllCitiesQuery : IRequest<CitiesListModel>
    {
    }

    public class GetAllQueryHandler : IRequestHandler<GetAllCitiesQuery, CitiesListModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllQueryHandler(
            IApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CitiesListModel> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context
               .Cities
               .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
               .AsNoTracking()
               .ToListAsync();

            if (entities == null)
            {
                throw new ArgumentException();
            }

            return new CitiesListModel
            {
                Cities = entities
            };
        }
    }
}
