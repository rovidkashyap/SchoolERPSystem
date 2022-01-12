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
    public class ClassSectionRepository : GenericRepository<ClassSection>, IClassSectionRepository
    {
        public ClassSectionRepository(DbContext context)
            : base(context)
        {

        }

        public ClassSection GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
