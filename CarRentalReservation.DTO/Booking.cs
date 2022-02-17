using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalReservation.DTO
{
    public class Booking
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime ? StartDate { get; set; }
        public DateTime ? ReturnDate { get; set; }
        public string CarRegNumber { get; set; }
 
    }
}
 