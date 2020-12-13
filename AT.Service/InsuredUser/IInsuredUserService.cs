using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AT.Service
{
    public interface IInsuredUserService
    {
        void Add(InsuredUser insuredUser);
        void Update(InsuredUser insuredUser);
        void Delete(InsuredUser insuredUser);
        InsuredUser GetById(int id);
        IEnumerable<InsuredUser> GetAll();
        IQueryable<InsuredUser> GetAllInclude();
    }
}
