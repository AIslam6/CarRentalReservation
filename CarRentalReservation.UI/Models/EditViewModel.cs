using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CarRentalReservation.UI.Models
{
    public class EditViewModel
    {
        public List<SelectListItem> CarList { get; set; }

        public DTO.Booking booking { get; set; }
       
        // public DTO.Customer customer { get; set; }

    }
}