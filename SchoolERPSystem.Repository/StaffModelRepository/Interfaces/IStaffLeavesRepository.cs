using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StaffModelRepository.Interfaces
{
    public interface IStaffLeavesRepository : IGenericRepository<StaffLeaves>
    {
        StaffLeaves GetById(string id);
    }
}
