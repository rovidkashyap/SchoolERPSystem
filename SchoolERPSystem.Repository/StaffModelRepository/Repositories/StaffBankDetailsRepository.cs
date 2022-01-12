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
    public class StaffBankDetailsRepository : GenericRepository<StaffBankDetails>, IStaffBankDetailsRepository
    {
        public StaffBankDetailsRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffBankDetails> GetAll()
        {
            return _entities.Set<StaffBankDetails>().AsEnumerable();
        }

        public StaffBankDetails GetById(string id)
        {
            return _dbset.Where(x => x.ApplicationUserId == id).FirstOrDefault();
        }
    }
}
