using AT.Core.Repository;
using AT.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AT.Service
{
    public class InsuredUserService : IInsuredUserService
    {
        private readonly IRepository<InsuredUser> _repository;
        public InsuredUserService(IRepository<InsuredUser> repository)
        {
            _repository = repository;
        }
        public void Add(InsuredUser insuredUser)
        {
            _repository.Add(insuredUser);
        }

        public void Delete(InsuredUser insuredUser)
        {
            _repository.Delete(insuredUser);
        }

        public IEnumerable<InsuredUser> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<InsuredUser> GetAllInclude()
        {
            return _repository.Include(x => x.City, x => x.District).AsQueryable();
        }

        public InsuredUser GetById(int id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public void Update(InsuredUser insuredUser)
        {
            _repository.Update(insuredUser);
        }
    }
}
