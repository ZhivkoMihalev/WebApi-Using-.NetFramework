namespace UnifOfWorkDbContext
{
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Threading.Tasks;

    public interface IUnifOfWorkDbContext
    {
        IGenericRepository<Car> CarRepository { get; }

        Task SaveChangesAsync();
    }
}
