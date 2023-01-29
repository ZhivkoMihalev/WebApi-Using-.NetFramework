namespace PariPlayCars.Services.DataServices.Operators
{
    using System;
    using System.Threading.Tasks;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;

    public class CarRemover : CarOperator
    {
        private readonly ILogger _logger;

        public CarRemover(ICarService service, ILogger logger)
            : base(service)
        {
            this._logger = logger;
        }

        public override async Task DeleteAsync(CarDTO car)
        {
            try
            {
                await base.DeleteAsync(car);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }
    }
}
