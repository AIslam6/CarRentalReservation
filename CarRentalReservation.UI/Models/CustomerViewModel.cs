using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRentalReservation.DTO;

namespace CarRentalReservation.UI.Models
{
    public class CustomerViewModel
    {
        public List<DTO.Customer> Customers { get; set; }
           
    }
}