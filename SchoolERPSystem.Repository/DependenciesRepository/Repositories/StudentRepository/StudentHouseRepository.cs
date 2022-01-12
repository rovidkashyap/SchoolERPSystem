using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Repositories.StudentRepository
{
    public class StudentHouseRepository : GenericRepository<StudentHouse>, IStudentHouseRepository
    {
        public StudentHouseRepository(DbContext context)
            : base(context)
        {

        }

        public StudentHouse GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
