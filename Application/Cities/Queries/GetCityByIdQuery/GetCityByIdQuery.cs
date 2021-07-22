using Application.Cities.Models;
using Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cities.Queries.GetCityByIdQuery
{
    public class GetCityByIdQuery : IRequest<CityDto>
    {
        public int Id { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(
            IApplicationDbContext context,
            IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context
               .Cities.Include(x =>x.Parkings).FirstOrDefaultAsync(x =>x.Id == request.Id);

            if (entity == null)
            {
                return new CityDto();
            }

            return _mapper.Map<CityDto>(entity);
        }
    }
}
