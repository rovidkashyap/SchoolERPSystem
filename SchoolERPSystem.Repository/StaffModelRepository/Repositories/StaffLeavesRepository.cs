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
    public class StaffLeavesRepository : GenericRepository<StaffLeaves>, IStaffLeavesRepository
    {
        public StaffLeavesRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffLeaves> GetAll()
        {
            return _entities.Set<StaffLeaves>().AsEnumerable();
        }

        public StaffLeaves GetById(string id)
        {
            return _dbset.Where(x => x.ApplicationUserId == id).FirstOrDefault();
        }
    }
}
