using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StaffModelRepository.Interfaces
{
    public interface IStaffProfileImageRepository : IGenericRepository<StaffProfileImage>
    {
        StaffProfileImage GetById(string id);
    }
}
