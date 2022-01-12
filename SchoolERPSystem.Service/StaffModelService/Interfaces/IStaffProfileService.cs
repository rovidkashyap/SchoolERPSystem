using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StaffModelService.Interfaces
{
    public interface IStaffProfileService : IEntityService<StaffProfile>
    {
        StaffProfile GetById(int? id);
        StaffProfile GetById(string id);

        int GetCountByRoleName(string rolename);
    }
}
