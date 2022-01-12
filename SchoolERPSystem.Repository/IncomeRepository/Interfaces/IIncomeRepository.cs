using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.IncomeRepository.Interfaces
{
    public interface IIncomeRepository : IGenericRepository<Income>
    {
        Income GetById(int id);
    }
}
