using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service
{
    public interface IDistrictService
    {
        IEnumerable<District> GetDistrictList(int cityId);
    }
}
