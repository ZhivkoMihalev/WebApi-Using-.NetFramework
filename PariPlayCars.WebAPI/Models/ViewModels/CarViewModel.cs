using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PariPlayCars.WebAPI.Models.ViewModels
{
    public class CarViewModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }
    }
}