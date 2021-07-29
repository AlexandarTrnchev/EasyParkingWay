using Application.Common.Interfaces;
using Application.Payments.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Payments.Queries.GetAllPaymentQuery
{
    public class GetAllPaymentsQuery : IRequest<PaymentDtoListModel>
    {
        public int? Id { get; set; }
        public string UserId { get; set; }
    }

    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, PaymentDtoListModel>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPaymentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaymentDtoListModel> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            var response = new PaymentDtoListModel();

            var query =  _context.Payments
                .Include(x => x.ParkingPlace)
                .ThenInclude(x => x.Parking)
                .OrderByDescending(x => x.Created);

            if (request.Id != null)
            {
                query = (IOrderedQueryable<Payment>)query.Where(x => x.Id == request.Id);
            }

            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = (IOrderedQueryable<Payment>)query.Where(x => x.UserId == request.UserId);
            }

            response.Payments = await query.Select(x =>
                    new PaymentModel
                    {
                        Id = x.Id,
                        ParkingPlaceId = x.ParkingPlaceId,
                        Address = x.ParkingPlace.Parking.Address,
                        Amount = x.Amount,
                        City = x.ParkingPlace.Parking.City.Name,
                        ParkingId = x.ParkingPlace.ParkingId,
                        ParkingName = x.ParkingPlace.Parking.Name,
                        ParkingNumber = x.ParkingPlace.Number,
                        RentFrom = (DateTime)x.RentFrom,
                        RentTo = (DateTime)x.RentTo,
                        CreatedDate = x.Created
                    })
                    .AsNoTracking()
                    .ToListAsync();

            return response;
        }
    }
}
