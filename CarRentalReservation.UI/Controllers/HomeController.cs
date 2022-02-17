using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRentalReservation.BLL;
using CarRentalReservation.DAL;


namespace CarRentalReservation.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CarRentalReservation.UI.Models.CustomerViewModel cvm = new CarRentalReservation.UI.Models.CustomerViewModel();
            CarRentalReservation.BLL.CarRentalManager crm = new CarRentalReservation.BLL.CarRentalManager();
            List<DTO.Customer> Customers = crm.GetCustomer();
            cvm.Customers = new List<DTO.Customer>();

            foreach (DTO.Customer Customer in Customers)
            {
                cvm.Customers.Add(Customer);
            }
            return View(cvm);
        }

        public ActionResult BookedCustomers()
        {
            CarRentalReservation.UI.Models.BookedViewModel bvm = new CarRentalReservation.UI.Models.BookedViewModel();
            CarRentalReservation.BLL.CarRentalManager crm = new CarRentalReservation.BLL.CarRentalManager();
            List<DTO.Customer> Booked = crm.GetBookedCustomers();
            bvm.BookedCustomers = new List<DTO.Customer>();
            bvm.BookedCustomers = Booked;
            return View(bvm);
        }


        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string action, CarRentalReservation.UI.Models.LoginViewModel lvm) 
        {
            if (ModelState.IsValid)
            {
                if (action == "Login")
                {
                    DTO.Login login = new DTO.Login()
                    {
                        Username = lvm.Login.Username,
                        Password = lvm.Login.Password,
                    
                    };
                    CarRentalManager crm = new CarRentalManager();
                    bool matched = crm.Login(login);
                    if (matched == true) 
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View(lvm);
                    }
                }
                else
                {
                    return View(lvm);
                }

            }
            else
            {
                return View(lvm);
            }
           // return View();
        }

        public ActionResult Car()
        {
            CarRentalReservation.UI.Models.CarViewModel carvm = new CarRentalReservation.UI.Models.CarViewModel();
            //CarRentalReservation.DAL.CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
            carvm.Cars = new List<DTO.Car>();

            CarRentalReservation.BLL.CarRentalManager crm = new CarRentalReservation.BLL.CarRentalManager();
            List<DTO.Car> cars = crm.GetCar();
            carvm.Cars = cars;
            return View(carvm);
        }

        public ActionResult Edit(int id)
        {
            CarRentalReservation.UI.Models.EditViewModel evm = new CarRentalReservation.UI.Models.EditViewModel();
            CarRentalReservation.BLL.CarRentalManager crm = new CarRentalReservation.BLL.CarRentalManager();
            DTO.Customer Cust = crm.GetCustomerName(id);
            evm.booking = new DTO.Booking();

            evm.booking.CustomerFirstName = Cust.FirstName;
            evm.booking.CustomerSurname = Cust.LastName;
            evm.booking.StartDate = null;
            evm.booking.ReturnDate = null;
            evm.booking.CustomerId = Cust.CustomerId;

      
            evm.CarList = (from dv in crm.GetCarList()
                                       select new SelectListItem()
                                       {
                                           Text = dv.CarRegNo,
                                           Value = dv.CarId.ToString(),
                                       }).ToList();             

            return View(evm);
        }

        [HttpPost]
        public ActionResult Edit( CarRentalReservation.UI.Models.EditViewModel evm, string action ) 
        {

            if (ModelState.IsValid)
            {
                if (action == "UpdateBooking")
                {
                   // evm.booking   = new DTO.Booking()
                    DTO.Booking bookg = new DTO.Booking()
                    {
                         CustomerFirstName = evm.booking.CustomerFirstName,
                         CustomerSurname = evm.booking.CustomerSurname,
                         CarRegNumber = evm.booking.CarRegNumber,
                         StartDate = evm.booking.StartDate,
                         ReturnDate = evm.booking.ReturnDate,
                          
                          CustomerId = evm.booking.CustomerId
                    };
                    CarRentalManager crm = new CarRentalManager();
                    crm.UpdateBooking(bookg);
                }

            }

            else
            {

            }



            return View(evm);
        }

        public ActionResult PaymentRecieved (int id)
        {
            CarRentalReservation.UI.Models.PaymentViewModel pvm = new CarRentalReservation.UI.Models.PaymentViewModel();
            CarRentalReservation.BLL.CarRentalManager crm = new CarRentalReservation.BLL.CarRentalManager();
            DTO.Customer Cust = crm.GetCustomerName(id);
            pvm.customer = new DTO.Customer();

            pvm.customer.FirstName = Cust.FirstName;
            pvm.customer.LastName = Cust.LastName;
           // pvm.customer.StartDate = Cust.StartDate;
           // pvm.customer.ReturnDate = Cust.ReturnDate;
            pvm.customer.CustomerId = Cust.CustomerId;

            // get payment total from payment table
            DTO.Payment paymentdetails = crm.GetPaymentTotal(id);
            pvm.payment = paymentdetails;
            return View(pvm);
        }

        [HttpPost] 
        public ActionResult PaymentRecieved (CarRentalReservation.UI.Models.PaymentViewModel pvm)
        {
            return View();
        }

    }
}