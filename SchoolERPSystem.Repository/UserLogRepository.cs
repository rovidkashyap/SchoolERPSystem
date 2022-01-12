using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository
{
    public class UserlogRepository : GenericRepository<UserLog>, IUserLogRepository
    {
        public UserlogRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<UserLog> GetAll()
        {
            return _entities.Set<UserLog>().AsEnumerable();
        }

        public UserLog GetById(string Id)
        {
            return _dbset.Where(x => x.ApplicationUserId == Id).FirstOrDefault();
        }
    }
}
