using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StudentModelRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StudentModelRepository.Repositories
{
    public class StudentAdmissionRepository : GenericRepository<StudentAdmission>, IStudentAdmissionRepository
    {
        public StudentAdmissionRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<StudentAdmission> GetAll()
        {
            return _entities.Set<StudentAdmission>().Include(x => x.BloodGroupName).Include(x => x.CategoryName).Include(x => x.ClassName).Include(x => x.GenderName).Include(x => x.StudentHouseName).AsEnumerable();
        }

        public StudentAdmission GetById(int id)
        {
            return _dbset.Include(x => x.BloodGroupName).Include(x => x.CategoryName).Include(x => x.ClassName).Include(x => x.GenderName).Include(x => x.StudentHouseName).Where(x => x.Id == id).FirstOrDefault();
        }

        public int StudentCount()
        {
            return _dbset.Count();
        }
    }
}
