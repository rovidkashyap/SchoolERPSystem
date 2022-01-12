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
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(DbContext context)
            : base(context)
        {

        }

        public Income GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
