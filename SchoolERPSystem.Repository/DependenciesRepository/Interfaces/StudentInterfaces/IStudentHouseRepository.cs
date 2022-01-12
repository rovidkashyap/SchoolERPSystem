using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Interfaces.StudentInterfaces
{
    public interface IStudentHouseRepository : IGenericRepository<StudentHouse>
    {
        StudentHouse GetById(int id);
    }
}
