using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //ToDo: Check Dependency inversion
        DbSet<City> Cities { get; set; }

        DbSet<Parking> Parkings { get; set; }

        DbSet<ParkingPlace> ParkingPlaces { get; set; }

        DbSet<Payment> Payments { get; set; }

        DatabaseFacade Database { get; }

        EntityEntry Add(object entity);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        void RollbackTransaction();
    }
}
