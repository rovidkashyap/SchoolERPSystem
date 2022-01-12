using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StudentModelRepository.Interfaces
{
    public interface IStudentAdmissionRepository : IGenericRepository<StudentAdmission>
    {
        StudentAdmission GetById(int id);

        int StudentCount();
    }
}
