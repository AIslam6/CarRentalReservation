using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalReservation.DTO;
using CarRentalReservation.DAL;

namespace CarRentalReservation.BLL
{
    public class CarRentalManager
    {
        public List< DTO.Customer> GetCustomer()
        {
           // DTO.Customer z = null;

            CarRentalReservation.DAL.CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
            List<DTO.Customer> Customers = cdc.GetCustomer();
            foreach(DTO.Customer customer in Customers)
            {
                if (customer.Booked == true)
                {
                    customer.Boooked = "Yes";
                }
                else
                {
                    customer.Boooked = "No";
                }
               
            }

            return Customers;
        }

        public List<DTO.Customer> GetBookedCustomers()
        {
            CarRentalReservation.DAL.CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
            List<DTO.Customer> Booked = cdc.GetBookedCustomers();

            return Booked;
        }

        public List<DTO.Car> GetCar(/*int id*/)

        {
            CarRentalReservation.DAL.CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
            List<DTO.Car> cars = cdc.GetCar();

         //   foreach(DTO.Car car in cars)
         //   {
         //       if (car.Available == true) 
         //       {
         //          car.Availability = "Yes";
         //       }
         //       else 
         //       {
         //           car.Availability = "No";
         //      }
         //   }
           return cars; 
        }
        public void UpdateBooking(DTO.Booking bookg)
        {
          CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
          cdc.UpdateBooking(bookg);
        }
        public DTO.Customer GetCustomerName(int id) 
        {
            CarRentalReservation.DAL.CarRentResDataController cdc = new CarRentalReservation.DAL.CarRentResDataController();
            return cdc.GetCustomerName(id);  
        }
        public List<Car> GetCarList()
        {
            CarRentResDataController dc = new CarRentResDataController();
            return dc.GetCarList();
            
            
        }
        public bool Login(DTO.Login login)
        {
        return true;
        }
        public DTO.Payment GetPaymentTotal (int id) 
        {
            CarRentResDataController cdc = new CarRentResDataController();
            
            return cdc.GetPaymentTotal(id);

        }
    }
}
