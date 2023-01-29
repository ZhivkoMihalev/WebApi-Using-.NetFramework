namespace PariPlayCars.Services.DataServices.Operators
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using PariplayCars.Data.Logs.NLog;
    using PariPlayCars.Services.DataServices.Models;
    using PariPlayCars.Services.DataServices.Contracts;

    public class CarGetter : CarOperator
    {
        private readonly ILogger _logger;

        public CarGetter(ICarService service, ILogger logger)
            : base(service)
        {
            this._logger = logger;
        }

        public override async Task<IEnumerable<CarDTO>> GetAllAsync()
        {
            try
            {
                return await base.GetAllAsync();
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                return null;
            }
        }

        public override async Task<CarDTO> GetByIdAsync(string id)
        {
            try
            {
                return await base.GetByIdAsync(id);
            }

            catch (Exception ex)
            {
                this._logger.WriteException(ex);
                return null;
            }
        }
    }
}
