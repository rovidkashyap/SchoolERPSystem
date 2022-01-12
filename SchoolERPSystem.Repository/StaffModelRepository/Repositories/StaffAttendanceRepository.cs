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
    public class StaffAttendanceRepository : GenericRepository<StaffAttendance>, IStaffAttendanceRepository
    {
        public StaffAttendanceRepository(DbContext context)
            : base(context)
        {
        }

        public override IEnumerable<StaffAttendance> GetAll()
        {
            return _entities.Set<StaffAttendance>().AsEnumerable();
        }

        public StaffAttendance GetById(int id)
        {
            return _dbset.Include(x => x.Id == id).FirstOrDefault();
        }

    }
}
