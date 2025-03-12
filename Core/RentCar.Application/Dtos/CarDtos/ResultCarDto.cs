using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Dtos.CarDtos
{
    public class ResultCarDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int KM { get; set; }
        public string Type { get; set; }
        public string Fuel { get; set; }
        public decimal DailyPrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
