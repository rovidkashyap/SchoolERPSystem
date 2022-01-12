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
    public class MaritalStatusRepository : GenericRepository<MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(DbContext context)
            : base(context)
        {
        }

        public MaritalStatus GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
