namespace PariPlayCars.Services.DataServices.Operators
{
    using System;
    using System.Threading.Tasks;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;

    public class CarEditor : CarOperator
    {
        private readonly ILogger _logger;

        public CarEditor(ICarService service, ILogger logger)
            : base(service)
        {
            this._logger = logger;
        }

        public override async Task Update(string id, CarDTO newCar)
        {
            try
            {
                await base.Update(id, newCar);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
            }
        }
    }
}
