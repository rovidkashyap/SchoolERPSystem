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
    public class StaffDocumentsRepository : GenericRepository<StaffDocuments>, IStaffDocumentsRepository
    {
        public StaffDocumentsRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffDocuments> GetAll()
        {
            return _entities.Set<StaffDocuments>().AsEnumerable();
        }

        public StaffDocuments GetById(string id)
        {
            return _dbset.Where(x => x.ApplicationUserId == id).FirstOrDefault();
        }
    }
}
