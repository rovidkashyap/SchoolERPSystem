using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.AcademicsService.Interfaces
{
    public interface ISubjectService : IEntityService<Subject>
    {
        Subject GetById(int id);
    }
}
