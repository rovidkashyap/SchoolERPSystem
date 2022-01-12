using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Repositories
{
    public class ContractTypeRepository : GenericRepository<ContractType>, IContractTypeRepository
    {
        public ContractTypeRepository(DbContext context)
            : base(context)
        {
        }

        public ContractType GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
