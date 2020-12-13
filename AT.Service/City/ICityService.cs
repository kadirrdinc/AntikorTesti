using AT.Core.Repository;
using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AT.Service
{
    public interface ICityService 
    {
        IEnumerable<City> GetAll();
    }
}
