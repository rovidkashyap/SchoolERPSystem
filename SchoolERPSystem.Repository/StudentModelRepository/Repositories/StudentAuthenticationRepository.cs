using SchoolERPSystem.Models.Authentication;
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
    public class StudentAuthenticationRepository : GenericRepository<StudentAuthentication>, IStudentAuthenticationRepository
    {
        public StudentAuthenticationRepository(DbContext context)
            : base(context)
        {

        }

        public StudentAuthentication GetById(int id)
        {
            return _dbset.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
