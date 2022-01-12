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
    public class StaffProfileImageRepository : GenericRepository<StaffProfileImage>, IStaffProfileImageRepository
    {
        public StaffProfileImageRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffProfileImage> GetAll()
        {
            return _entities.Set<StaffProfileImage>().AsEnumerable();

        }
        public StaffProfileImage GetById(string id)
        {
            return _dbset.Where(x => x.ApplicationUserId == id).FirstOrDefault();
        }
    }
}
