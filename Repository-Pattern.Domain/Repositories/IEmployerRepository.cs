using Repository_Pattern.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository_Pattern.Domain.Repositories
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Employer>> GetAll();
        Task<Employer> GetById(Guid id);
        void Add(Employer employer);
        void Update(Employer employer);
        void Delete(Guid id);
    }
}
