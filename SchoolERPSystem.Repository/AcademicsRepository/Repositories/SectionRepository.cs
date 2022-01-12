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
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(DbContext context)
            : base(context)
        {

        }

        public Section GetById(int id)
        {
            return FindBy(s => s.Id == id).FirstOrDefault();
        }
    }
}
