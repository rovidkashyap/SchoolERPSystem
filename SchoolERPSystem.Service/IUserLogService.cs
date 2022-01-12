using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service
{
    public interface IUserLogService : IEntityService<UserLog>
    {
        UserLog GetById(string Id);
    }
}
