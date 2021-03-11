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

            //CarDetailTest();

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
                BrandId = 2,
                ColorId = 1,
                DailyPrice = 200,
                ModelYear = "2021",
                Descriptions = "2021 model, manuel car."
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
