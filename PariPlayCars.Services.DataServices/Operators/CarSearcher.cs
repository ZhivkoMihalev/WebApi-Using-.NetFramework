namespace PariPlayCars.Services.DataServices.Operators
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;

    public class CarSearcher : CarOperator
    {
        private readonly ILogger _logger;

        public CarSearcher(ICarService service, ILogger logger)
            : base(service)
        {
            this._logger = logger;
        }

        public override async Task<IEnumerable<CarDTO>> SearchByBrandAsync(string search)
        {
            try
            {
                return await base.SearchByBrandAsync(search);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                return null;
            }
        }

        public override async Task<IEnumerable<CarDTO>> SearchByModelAsync(string search)
        {
            try
            {
                return await base.SearchByModelAsync(search);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                return null;
            }
        }
    }
}
