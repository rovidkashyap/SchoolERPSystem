using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Interfaces
{
    public interface IContractTypeService : IEntityService<ContractType>
    {
        ContractType GetById(int id);
    }
}
