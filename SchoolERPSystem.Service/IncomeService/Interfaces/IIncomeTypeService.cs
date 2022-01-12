using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.IncomeService.Interfaces
{
    public interface IIncomeTypeService : IEntityService<IncomeType>
    {
        IncomeType GetById(int id);
    }
}
