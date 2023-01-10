namespace AbstractDbContext
{
    using PariPlayCars.Data.Models;
    using Repositories.GenericRepo;
    using System.Threading.Tasks;

    public interface IAbstractDbContext
    {
        IGenericRepository<Car> CarRepository { get; }

        Task SaveChangesAsync();
    }
}
