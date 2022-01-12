using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Repository.AcademicsRepository.Interfaces;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.AcademicsRepository.Repositories
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(DbContext context)
            : base(context)
        {

        }

        public Subject GetById(int id)
        {
            return FindBy(s => s.Id == id).FirstOrDefault();
        }
    }
}
