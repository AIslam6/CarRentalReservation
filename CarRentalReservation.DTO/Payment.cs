﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalReservation.DTO
{
    public class Payment
    {
        public int CustomerId { get; set; }
        public int? PaymentTotal { get; set; }
        public bool paid { get; set; }
    }
}
