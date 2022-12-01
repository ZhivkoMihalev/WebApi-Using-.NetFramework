using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PariPlayCars.WebAPI.Models.InputModels
{
    public class CarInputModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Brand must be between 2 and 20 symbols.")]
        public string Brand { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model must be between 2 and 20 symbols.")]
        public string Model { get; set; }

        [Required]
        [Range(1900, 2050, ErrorMessage = "Year must be between 1900 and {DateTime.UtcNow.Year}.")]
        //TO DO: Range DateTime.UtcNow.Year
        public int Year { get; set; }
    }
}