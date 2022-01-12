using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.AcademicsRepository.Interfaces
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        Subject GetById(int id);
    }
}
