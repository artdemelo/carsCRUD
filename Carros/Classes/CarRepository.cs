using System;
using System.Collections.Generic;
using Carros.Interfaces;

namespace Carros
{
    public class CarRepository : IRepository<Car>
    {
        private List<Car> listCar = new List<Car>();
        public void Delete(int id)
        {
            listCar[id].Delete();
        }

        public void Insert(Car entity)
        {
            listCar.Add(entity);
        }

        public List<Car> Listing()
        {
            return listCar;
        }

        public int NextId()
        {
            return listCar.Count;
        }

        public Car ReturnPerId(int id)
        {
            return listCar[id];
        }

        public void Update(int id, Car entity)
        {
            listCar[id] = entity;
        }
    }
}