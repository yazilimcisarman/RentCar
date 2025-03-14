using RentCar.Application.Dtos.UserDtos;
using RentCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.Application.Dtos.RentedCarDtos
{
    public class OnlyInfoRentedCarDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal DamagePrice { get; set; }
        public bool IsCompleted { get; set; }
    }
}
