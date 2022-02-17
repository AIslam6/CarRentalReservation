using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalReservation.DTO
{
    public class Car
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string CarRegNo { get; set; }
        public bool Available { get; set; }
        public string Availability { get; set; }
    }
}
