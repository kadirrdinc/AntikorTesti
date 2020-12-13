using AT.Core.Repository;
using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service
{
    public class DistrictService : IDistrictService
    {
        private readonly IRepository<District> _districtRepository;
        private readonly IRepository<City> _cityRepository;
        public DistrictService(IRepository<District> districtRepository, IRepository<City> cityRepository)
        {
            _districtRepository = districtRepository;
            _cityRepository = cityRepository;
        }
        public IEnumerable<District> GetDistrictList(int cityId)
        {
            if (cityId == null)
                throw new ArgumentNullException();

            var list = _districtRepository.GetAll(x => x.CityId == cityId);

            return list;
        }
    }
}
