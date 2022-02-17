using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalReservation.UI.Models
{
    public class CarViewModel
    {
        public List<DTO.Car> Cars { get; set; }
        public string Available { get; set; }
        public string Availability { get; set; }
    }
}