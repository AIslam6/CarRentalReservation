using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalReservation.DTO
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Booked { get; set; }
        public string Boooked { get; set; }
        public int BookingId { get; set; }
        public string CarRegNo { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public float? PaymentTotal { get; set; }
    }
}
