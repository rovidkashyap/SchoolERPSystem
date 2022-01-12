using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StaffModelService.Interfaces
{
    public interface IStaffBankDetailsService : IEntityService<StaffBankDetails>
    {
        StaffBankDetails GetById(string id);
    }
}
