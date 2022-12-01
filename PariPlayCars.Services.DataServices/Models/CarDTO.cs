using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PariPlayCars.Services.DataServices.Models
{
    public class CarDTO
    {

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Brand must have between 2 and 20 symbols.")]
        public string Brand { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Model must have between 2 and 20 symbols.")]
        public string Model { get; set; }

        [Required]
        //TO DO: ValidationAttribute for range of years [Range(1900, DateTime.UtcNow.Year, ErrorMessage = .....)]
        public int Year { get; set; }
    }
}
