using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Interfaces
{
    public interface IDesignationRepository : IGenericRepository<Designation>
    {
        Designation GetById(int id);
    }
}
