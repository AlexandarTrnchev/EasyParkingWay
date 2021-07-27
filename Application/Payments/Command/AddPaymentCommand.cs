using Application.Common.Interfaces;
using Application.Payments.Models;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Payments.Command
{
    public class AddPaymentCommand : IRequest<bool>
    {
        public string UserId { get; set; }
        public PaymentModel PaymentModel { get; set; }
    }

    public class AddPaymentCommandHandler : IRequestHandler<AddPaymentCommand, bool>
    {
        private readonly IApplicationDbContext _dbContext;

        public AddPaymentCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddPaymentCommand request, CancellationToken cancellationToken)
        {
            //ToDo Need to be add Validation
            var entity = new Payment();

            entity.Amount = request.PaymentModel.Amount;
            entity.ParkingPlaceId = request.PaymentModel.ParkingPlaceId;
            entity.RentFrom = request.PaymentModel.RentFrom;
            entity.RentTo = request.PaymentModel.RentTo;
            entity.UserId = request.UserId;
            try
            {
                await _dbContext.Payments.AddAsync(entity);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
