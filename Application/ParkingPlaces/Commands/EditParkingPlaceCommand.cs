using Application.Common.Interfaces;
using Application.ParkingPlaces.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ParkingPlaces.Commands
{
    public class EditParkingPlaceCommand : IRequest<int>
    {
        public EditParkingPlaceModel Data { get; set; }
    }

    public class EditParkingPlaceCommandHandler : IRequestHandler<EditParkingPlaceCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public EditParkingPlaceCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(EditParkingPlaceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext
                .ParkingPlaces
                .FirstOrDefaultAsync(x => x.Id == request.Data.Id);


            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.Number = request.Data.Number;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return request.Data.ParkingId;
        }
   }
}
