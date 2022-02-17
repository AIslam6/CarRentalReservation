using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentalReservation.UI.Models
{
    public class PaymentViewModel
    {
        public DTO.Customer customer { get; set; }
        public DTO.Payment payment { get; set; }
    }
}