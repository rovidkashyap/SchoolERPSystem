using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StaffModelRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StaffModelRepository.Repositories
{
    public class StaffProfileRepository : GenericRepository<StaffProfile>, IStaffProfileRepository
    {
        public StaffProfileRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffProfile> GetAll()
        {
            return _entities.Set<StaffProfile>().Include(x => x.DepartmentName).Include(x => x.DepartmentName).Include(x => x.GenderName).Include(x => x.MaritalStatusName).AsEnumerable();
        }

        public StaffProfile GetById(int? id)
        {
            return _dbset.Include(x => x.DepartmentName).Include(x => x.DepartmentName).Include(x => x.GenderName).Include(x => x.MaritalStatusName).Where(x => x.Id == id).FirstOrDefault();
        }

        public StaffProfile GetById(string id)
        {
            return _dbset.Include(x => x.DepartmentName).Include(x => x.DepartmentName).Include(x => x.GenderName).Include(x => x.MaritalStatusName).Where(x => x.ApplicationUserId == id).FirstOrDefault();

        }

        public int GetCountByRoleName(string rolename)
        {
            return _dbset.Where(x => x.RoleName == rolename).Count();
        }

    }
}
