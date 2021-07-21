using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cities.Queries.GetAllCitiesQuery
{
    public class GetAllCitiesQuery : IRequest<string>
    {
    }

    public class GetAllQueryHandler : IRequestHandler<GetAllCitiesQuery, string>
    {
        //private readonly IApplicationDbContext _context;
        //private readonly IMapper _mapper;

        public GetAllQueryHandler(
            //IApplicationDbContext context, IMapper mapper
            )
        {
            //_context = context;
            //_mapper = mapper;
        }

        public async Task<string> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            return "Sofia";
        }
    }
}
