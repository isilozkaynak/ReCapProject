using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carDals;

        public InMemoryCarDal()
        {
            _carDals = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2019, 1, 5", DailyPrice=500000, Descriptions="Car description." },
                new Car{Id=2, BrandId=2, ColorId=1, ModelYear="2010, 5, 1", DailyPrice=100000, Descriptions="Car description." },
                new Car{Id=3, BrandId=2, ColorId=2, ModelYear="2016, 4, 20", DailyPrice=320000, Descriptions="Car description." },
                new Car{Id=4, BrandId=3, ColorId=2, ModelYear="2009, 7, 7", DailyPrice=90000, Descriptions="Car description." },
                new Car{Id=5, BrandId=4, ColorId=2, ModelYear="2017, 2, 2", DailyPrice=444000, Descriptions="Car description." },
            };
        }

        public void Add(Car car)
        {
            _carDals.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _carDals.SingleOrDefault(c => c.Id == car.Id);
            _carDals.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _carDals;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _carDals.Where(c => c.Id == id).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _carDals.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }
    }
}
