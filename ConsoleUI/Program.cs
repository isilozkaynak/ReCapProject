using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* CAR
            //CarTest();
            //ListByBrandId();
            //AddCarTest();
            //DeleteCarTest();
            //UpdateCarTest();
            //ListAllCar();
            */

            /*BRAND
            //AddBrandTest();
            //UpdateBrandTest();
            //DeleteBrandTest();
            //BrandGetByIdTest();
            //ListAllBrandsTest();
            */

            /*COLOR
            //AddColorTest();
            //UpdateColorTest();
            //DeleteColorTest();
            //ColorGetByIdTest();
            //ListAllColorsTest();
            */


            //CarSuccessTest();
            //CarDetailTest();



            /*USER
            //AddUserTest();
            //DeleteUserTest();
            //UpdateUserTest();
            //ListedGetByIdUser();
            //ListedUserTest();
            */

            /*CUSTOMER
            //AddCustomerTest();
            //ListedCustomerTest();
            //DeleteCustomerTest();
            //UpdateCustomerTest();
            //ListedGetByIdCustomerTest();
            */

            /*RENTAL
            //AddRentalTest();
            //UpdateRentalTest();
            //DeleteRentalTest();
            //ListedGetByIdRentalTest();
            //ListedRentalTest();
            */



            //CustomerSuccessTest();
            //CustomerDetailDtoTest();






            AddRentalTest();
            //DeleteRentalTest();
            ListedRentalTest();

        }

        private static void AddRentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Insert(new Rental
            {
                CarId = 4,
                CustomerId = 5,
                RentDate = new DateTime(2021, 03, 17),
                ReturnDate = new DateTime(2021, 03, 21)
            });


            if (result.Success == true)
            {
                Console.WriteLine("Sisteme Eklendi.");

            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }



        private static void CustomerSuccessTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetCustomerDetails();

            if (result.Success == true)
            {
                foreach (var customer in result.Data)
                {
                    Console.WriteLine(customer.CompanyName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CustomerDetailDtoTest()
        {
            CustomerManager detailCustomer = new CustomerManager(new EfCustomerDal());
            foreach (var customer in detailCustomer.GetCustomerDetails().Data)
            {
                Console.WriteLine("customerId: " + customer.CustomerId
                        + "\nUserId: " + customer.UserId + "\nCompany Name: " +
                        customer.CompanyName + "\nFirst Name: " + customer.FirstName +
                        "\nLast Name: " + customer.LastName + "\nEmail: " + customer.Email
                        + "\nTeslim Tarihi: " + customer.ReturnDate);
                Console.WriteLine("----------------------------------");
            }
        }

        private static void ListedGetByIdRentalTest()
        {
            RentalManager listGetByIdRental = new RentalManager(new EfRentalDal());
            Console.WriteLine(listGetByIdRental.GetById(1).Data.ReturnDate);
        }

        private static void DeleteRentalTest()
        {
            RentalManager deleteRental = new RentalManager(new EfRentalDal());
            deleteRental.Delete(new Rental
            {
                RentalId = 4
            });
        }

        private static void UpdateRentalTest()
        {
            RentalManager updateRental = new RentalManager(new EfRentalDal());
            updateRental.Update(new Rental
            {
                RentalId = 2,
                CarId = 2,
                CustomerId = 5,
                RentDate = new DateTime(2021, 03, 15, 10, 45, 00),
                ReturnDate = new DateTime(2021, 03, 17, 20, 30, 00)
            });
        }

       

        private static void ListedRentalTest()
        {
            RentalManager listedRent = new RentalManager(new EfRentalDal());
            foreach (var rent in listedRent.GetAll().Data)
            {
                Console.WriteLine("RentalId= " + rent.RentalId +
                    ", CarId= " + rent.CarId +
                    ", CustomerId= " + rent.CustomerId +
                    ", Kiralama günü= " + rent.RentDate +
                    ", Teslim günü= " + rent.ReturnDate);
            }
        }

        private static void UpdateCustomerTest()
        {
            CustomerManager updateCustomer = new CustomerManager(new EfCustomerDal());
            updateCustomer.Update(new Customer
            {
                CustomerId = 3,
                UserId = 1002,
                CompanyName = "Müşteri2"
            });
        }

        private static void ListedGetByIdCustomerTest()
        {
            CustomerManager listedGetByIdC = new CustomerManager(new EfCustomerDal());
            Console.WriteLine(listedGetByIdC.GetById(5).Data.CustomerId);
        }

        private static void ListedGetByIdUser()
        {
            UserManager listedGetById = new UserManager(new EfUserDal());
            Console.WriteLine(listedGetById.GetById(2).Data.FirstName);
        }

        private static void UpdateUserTest()
        {
            UserManager updateUser = new UserManager(new EfUserDal());
            updateUser.Update(new User
            {
                UserId = 2,
                FirstName = "Işıl",
                LastName = "Özkaynak",
                Email = "isil@gmail.com",
                Passwords = "123456"
            });
        }

        private static void DeleteUserTest()
        {
            UserManager deleteUser = new UserManager(new EfUserDal());
            deleteUser.Delete(new User
            {
                UserId = 3
            });
        }

        private static void DeleteCustomerTest()
        {
            CustomerManager deleteCustomer = new CustomerManager(new EfCustomerDal());
            deleteCustomer.Delete(new Customer
            {
                CustomerId = 6
            });
        }

        private static void ListedCustomerTest()
        {
            CustomerManager listAllCustomer = new CustomerManager(new EfCustomerDal());
            foreach (var customer in listAllCustomer.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " --- " + customer.CompanyName
                    + ",  UserId: " + customer.UserId);
            }
        }

        private static void AddCustomerTest()
        {
            CustomerManager addCustomer = new CustomerManager(new EfCustomerDal());
            addCustomer.Insert(new Customer
            {
                UserId = 1003,
                CompanyName = "Müşteri4"
            });
        }

        private static void ListedUserTest()
        {
            Console.WriteLine("Users: ");
            UserManager listAllUser = new UserManager(new EfUserDal());
            foreach (var user in listAllUser.GetAll().Data)
            {
                Console.WriteLine(user.UserId + "=" + user.FirstName + " " +
                    user.LastName + ", " + user.Email + ", " + user.Passwords);
            }
        }

        private static void AddUserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Insert(new User
            {
                FirstName = "Salih",
                LastName = "Köse",
                Email = "sk@gmail.com",
                Passwords = "123456"
            });
        }

        private static void CarSuccessTest()
        {
            CarManager productManager = new CarManager(new EfCarDal());
            var result = productManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarDetailTest()
        {
            CarManager carDetail = new CarManager(new EfCarDal());

            foreach (var cars in carDetail.GetCarDetails().Data)
            {
                Console.WriteLine("BrandId: " + cars.BrandId
                    + "\nBrandName: " + cars.BrandName + "\nColorId: " +
                    cars.ColorId + "\nColorName: " + cars.ColorName +
                    "\nId: " + cars.Id + "\nDailyPrice: " + cars.DailyPrice);
                Console.WriteLine("----------------------------------");
            }
        }

        //COLOR-------------------------------------------------------------

        private static void ColorGetByIdTest()
        {
            ColorManager colorGetById = new ColorManager(new EfColorDal());
            Console.WriteLine(colorGetById.GetById(5).Data.ColorName);
        }

        private static void DeleteColorTest()
        {
            ColorManager deleteColor = new ColorManager(new EfColorDal());
            deleteColor.Delete(new Color { ColorId = 4 });
        }

        private static void UpdateColorTest()
        {
            ColorManager updateColor = new ColorManager(new EfColorDal());
            updateColor.Update(new Color { ColorId = 3, ColorName = "Red" });
        }

        private static void AddColorTest()
        {
            ColorManager addColor = new ColorManager(new EfColorDal());
            addColor.Insert(new Color
            {
                ColorName = "Silver"
            });
        }

        private static void ListAllColorsTest()
        {
            ColorManager listAllColors = new ColorManager(new EfColorDal());
            foreach (var colors in listAllColors.GetAll().Data)
            {
                Console.WriteLine(colors.ColorId + " - " + colors.ColorName);
            }
        }



        //BRAND------------------------------------------------------
        private static void BrandGetByIdTest()
        {
            BrandManager brandGetById = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandGetById.GetById(2).Data.BrandName);
        }

        private static void DeleteBrandTest()
        {
            BrandManager deleteBrand = new BrandManager(new EfBrandDal());
            deleteBrand.Delete(new Brand { BrandId = 7 });
        }

        private static void UpdateBrandTest()
        {
            BrandManager updateBrand = new BrandManager(new EfBrandDal());
            updateBrand.Update(new Brand { BrandId = 7, BrandName = "Fiat Linea" });
        }

        private static void ListAllBrandsTest()
        {
            BrandManager listAllBrand = new BrandManager(new EfBrandDal());
            foreach (var brands in listAllBrand.GetAll().Data)
            {
                Console.WriteLine(brands.BrandId + " - " + brands.BrandName);
            }
        }

        private static void AddBrandTest()
        {
            BrandManager addBrand = new BrandManager(new EfBrandDal());
            addBrand.Insert(new Brand { BrandName = "Fiat Doblo" });
        }

        private static void ListByBrandId()
        {
            CarManager listByBrandId = new CarManager(new EfCarDal());
            foreach (var cars in listByBrandId.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(cars.BrandId + " - " + cars.Descriptions);
            }
        }





        //CAR------------------------------------------------------
        private static void ListAllCar()
        {
            CarManager listAllCar = new CarManager(new EfCarDal());
            foreach (var cars in listAllCar.GetAll().Data)
            {
                Console.WriteLine(cars.Id + " --- " + cars.Descriptions);
            }
        }

        private static void AddCarTest()
        {
            CarManager addedCar = new CarManager(new EfCarDal());
            addedCar.Insert(new Car
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 550,
                ModelYear = "2020",
                Descriptions = "2020 model, automatic car."
            });
        }

        private static void DeleteCarTest()
        {
            CarManager deleteCar = new CarManager(new EfCarDal());
            deleteCar.Delete(new Car { Id = 1007 });
        }

        private static void UpdateCarTest()
        {
            CarManager updateCar = new CarManager(new EfCarDal());
            updateCar.Update(new Car
            {
                Id = 1006,
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 600000,
                ModelYear = "2020",
                Descriptions = "2020 model, automatic, diesel-powered vehicle"
            });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + cars.Id + ", " + cars.Descriptions);
            }

            CarManager carManager2 = new CarManager(new EfCarDal());

            Console.WriteLine(carManager2.GetCarsByBrandId(1).Data);
        }
    }
}
