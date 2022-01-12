using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.IncomeRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.IncomeRepository.Repositories
{
    public class IncomeTypeRepository : GenericRepository<IncomeType>, IIncomeTypeRepository
    {
        public IncomeTypeRepository(DbContext context)
            : base(context)
        {

        }

        public IncomeType GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
