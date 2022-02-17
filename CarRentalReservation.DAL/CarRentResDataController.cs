using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalReservation.DTO;

namespace CarRentalReservation.DAL
{
    public class CarRentResDataController
    {
        public List<DTO.Customer> GetCustomer()
        {
            
            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {
                List<DTO.Customer> CustomerList = (from cu in cdc.Customers
                                                       select new DTO.Customer
                                                       {
                                                           CustomerId = cu.CustomerId,
                                                           FirstName = cu.FirstName,
                                                           LastName = cu.LastName,
                                                          // Booked = cu.Booked,

                                                       }).ToList();
                return CustomerList;
            }
        }

        public List<DTO.Car> GetCar(/*int id*/)
        {

            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {
                List<DTO.Car> CarList = (from ca in cdc.Cars
                                                   select new DTO.Car
                                                   {
                                                       CarId = ca.CarId,
                                                       CarModel = ca.CarRegNo,
                                                       Available = ca.Available,

                                                   }).ToList();
                return CarList;
            }
        }
 
         public void UpdateBooking(DTO.Booking bookg)
        {
            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {
               
                DAL.CarRentalReservation.Booking newRecord = new DAL.CarRentalReservation.Booking ();

                newRecord.CustomerFirstName = bookg.CustomerFirstName;
                newRecord.CustomerSurname = bookg.CustomerSurname;
                newRecord.CarRegNumber = bookg.CarRegNumber;
                newRecord.StartDate = bookg.StartDate;
                newRecord.ReturnDate = bookg.ReturnDate;
               
                newRecord.CustomerId = bookg.CustomerId;   // <== HAVE TO TAKE THIS HARDCODE "1" OUT

                cdc.Bookings.Add(newRecord);
                cdc.SaveChanges();

                // return ord.OrderID;
                
                //  ( newRecord.BookingId; )

                InsertIntoCarTable (newRecord.BookingId, newRecord.CarRegNumber);
                //newRecord.CustomerId = 1;
                InsertIntoCustomerTable (newRecord.BookingId, newRecord.CustomerId);

            }
            
        }

        public void InsertIntoCarTable(int BookingId, string CarRegNo)
        {
            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {

                //DAL.CarRentalReservation.Car newRecord = new DAL.CarRentalReservation.Car();

                DAL.CarRentalReservation.Car Cr = (from c in cdc.Cars where c.CarRegNo == CarRegNo select c).FirstOrDefault();
                     
                     
                Cr.BookingId = BookingId;

                //cdc.Cars.Add(newRecord);
                cdc.SaveChanges();
            
            }
        }
        public void InsertIntoCustomerTable(int BookingId, int? CustomerId)
        {
            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {
                DAL.CarRentalReservation.Customer Cu = (from c in cdc.Customers where c.CustomerId == CustomerId select c).FirstOrDefault();
                Cu.BookingId = BookingId;
                cdc.SaveChanges();
            }
        }

         public DTO.Customer GetCustomerName(int id) 
         {
             using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
             {

                 DTO.Customer Cust = (from cu in cdc.Customers
                                                    where cu.CustomerId == id
                                                    select new DTO.Customer
                                                    {
                                                        CustomerId = cu.CustomerId,
                                                        FirstName = cu.FirstName,
                                                        LastName = cu.LastName,

                                                    }).FirstOrDefault();
                 return Cust;
             }
         }

        public List< DTO.Customer> GetBookedCustomers()
         {
             using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
             {

                List< DTO.Customer> CustList = (from b in cdc.Customers
                                      where b.BookingId != null
                                      select new DTO.Customer
                                      {
                                          CustomerId = b.CustomerId,
                                          FirstName = b.FirstName,
                                          LastName = b.LastName,

                                      }).ToList();  
                 return CustList; 
             }
         }


         public List<Car> GetCarList() 
         {
            List<Car> z = null;

            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {

                List<Car> CarList = (from c in cdc.Cars
                                     where c.BookingId == null
                                     select new DTO.Car
                                     {
                                         CarId = c.CarId,
                                         CarRegNo = c.CarRegNo,

                                     }).ToList();


                return CarList;
            }
         }
         public bool Login(DTO.Login login) 
         {
              
              using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
              {
                  bool matched = (from su in cdc.SystemUsers
                                  where su.Username == login.Username && su.Password == login.Password

                                  select true).FirstOrDefault();
             return matched;
              }
         }

        public DTO.Payment GetPaymentTotal (int id) 
        {
            using (CarRentalReservation.CarRentalReservationsEntities2 cdc = new CarRentalReservation.CarRentalReservationsEntities2())
            {

                DTO.Payment Cust = (from cu in cdc.Payments
                                     where cu.CustomerId == id
                                     select new DTO.Payment
                                     {
                                         CustomerId = cu.CustomerId,
                                         PaymentTotal = cu.PaymentTotal
            

                                     }).FirstOrDefault();
                return Cust;
            }
        }
    }
}
