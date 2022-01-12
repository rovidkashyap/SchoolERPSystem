using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Interfaces
{
    public interface IDesignationService : IEntityService<Designation>
    {
        Designation GetById(int id);
    }
}
