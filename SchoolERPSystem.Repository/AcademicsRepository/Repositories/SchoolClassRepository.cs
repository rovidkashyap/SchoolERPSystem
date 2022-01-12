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
    public class SchoolClassRepository : GenericRepository<SchoolClass>, ISchoolClassRepository
    {
        public SchoolClassRepository(DbContext context)
            : base(context)
        {

        }

        public SchoolClass GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
