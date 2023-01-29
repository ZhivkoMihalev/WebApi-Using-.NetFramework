namespace PariPlayCars.Services.DataServices
{
    using System;
    using System.Threading.Tasks;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;

    public class CarCreator : CarOperator
    {
        private readonly ILogger _logger;

        public CarCreator(ICarService service, ILogger logger)
            : base(service)
        {
            this._logger = logger;
        }

        public override async Task CreateAsync(CarDTO car)
        {
            try
            {
                await base.CreateAsync(car);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }
    }
}
