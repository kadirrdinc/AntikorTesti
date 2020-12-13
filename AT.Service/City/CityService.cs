using AT.Core.Repository;
using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service
{
    public class CityService: ICityService
    {
        private readonly IRepository<City> _repository;
        public CityService(IRepository<City> repository)
        {
            _repository = repository;
        }

        public IEnumerable<City> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
