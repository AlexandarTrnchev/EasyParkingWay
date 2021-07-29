using Application.Common.Interfaces;
using Application.Payments.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

            if (string.IsNullOrEmpty(request.UserId))
            {
                response.Payments = await _context
                    .Payments
                    .Include(x => x.ParkingPlace)
                    .ThenInclude(x => x.Parking)
                    .OrderByDescending(x =>x.Created)
                    .Select(x => 
                    new PaymentModel
                    { 
                        ParkingPlaceId = x.ParkingPlaceId,
                        Address = x.ParkingPlace.Parking.Address,
                        Amount = x.Amount,
                        City = x.ParkingPlace.Parking.City.Name,
                        ParkingId = x.ParkingPlace.ParkingId,
                        ParkingName = x.ParkingPlace.Parking.Name,
                        ParkingNumber = x.ParkingPlace.Number,
                        RentFrom = (DateTime)x.RentFrom,
                        RentTo = (DateTime)x.RentTo
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                response.Payments = await _context
                    .Payments
                    .Where(x => x.UserId == request.UserId)
                     .Include(x => x.ParkingPlace)
                    .ThenInclude(x => x.Parking)
                    .OrderByDescending(x => x.Created)
                    .Select(x =>
                    new PaymentModel
                    {
                        ParkingPlaceId = x.ParkingPlaceId,
                        Address = x.ParkingPlace.Parking.Address,
                        Amount = x.Amount,
                        City = x.ParkingPlace.Parking.City.Name,
                        ParkingId = x.ParkingPlace.ParkingId,
                        ParkingName = x.ParkingPlace.Parking.Name,
                        ParkingNumber = x.ParkingPlace.Number,
                        RentFrom = (DateTime)x.RentFrom,
                        RentTo = (DateTime)x.RentTo
                    })
                    .AsNoTracking()
                    .ToListAsync();
            }

            return response;
        }
    }
}
