using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ReceptionRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.ReceptionRepository.Repositories
{
    public class ReferenceRepository : GenericRepository<Reference>, IReferenceRepository
    {
        public ReferenceRepository(DbContext context)
            : base(context)
        {

        }

        public Reference GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
