using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PariPlayCars.Data.Models
{
    public class Car
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual string Brand { get; set; }

        [Required]
        public virtual string Model { get; set; }

        public virtual int Year { get; set; }
    }
}
