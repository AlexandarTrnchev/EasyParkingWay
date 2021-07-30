using Application.Common.Interfaces;
using Application.Parkings.Models;
using Application.Payments.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Parkings.Commands
{
    public class EditParkingCommand : IRequest<int>
    {
        public int Id { get; set; }
        public ParkingEditDto ParkingEditData { get; set; }
    }
    public class EditParkingCommandHandler : IRequestHandler<EditParkingCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public EditParkingCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(EditParkingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext
                .Parkings
                .FirstOrDefaultAsync(x => x.Id == request.Id);


            if (entity == null)
            {
                throw new Exception("Not Found");
            }

            entity.Name = request.ParkingEditData.Name;
            entity.PricePerParkingPlace = request.ParkingEditData.PricePerParkingPlace;
            entity.Address = request.ParkingEditData.Address;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return request.Id;
        }
    }
}
