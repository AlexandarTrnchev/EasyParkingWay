using Application.Common.Interfaces;
using Application.Parkings.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Parkings.Commands
{
    public class AddParkingCommand : IRequest<int>
    {
        public AddParkingModel Data { get; set; }
    }
    public class AddParkingCommandHandler : IRequestHandler<AddParkingCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AddParkingCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddParkingCommand request, CancellationToken cancellationToken)
        {
            var entity = new Parking
            {
                Address = request.Data.Address,
                Name = request.Data.Name,
                CityId = request.Data.CityId,
                PricePerParkingPlace = request.Data.PricePerParkingPlace,
                ParkingPlaces = new List<ParkingPlace>()
            };

            for (int i = 1; i <= request.Data.NumberParkingPlaces; i++)
            {
                entity.ParkingPlaces.Add(new ParkingPlace { Number = i });
            }
            
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return entity.Id;
        }
    }
}
