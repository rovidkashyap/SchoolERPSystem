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
    public class StaffPayrollRepository : GenericRepository<StaffPayroll>, IStaffPayrollRepository
    {
        public StaffPayrollRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffPayroll> GetAll()
        {
            return _entities.Set<StaffPayroll>().Include(x => x.ContractTypeName).AsEnumerable();
        }

        public StaffPayroll GetById(string id)
        {
            return _dbset.Include(x => x.ContractTypeName).Where(x => x.ApplicationUserId == id).FirstOrDefault();

        }
    }
}
