namespace UnitOfWorkDbContext
{
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Threading.Tasks;

    public interface IUnitOfWorkDbContext
    {
        IGenericRepository<Car> CarRepository { get; }

        Task SaveChangesAsync();
    }
}
