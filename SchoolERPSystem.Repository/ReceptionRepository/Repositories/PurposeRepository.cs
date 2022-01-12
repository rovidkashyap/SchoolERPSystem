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
    public class PurposeRepository : GenericRepository<Purpose>, IPurposeRepository
    {
        public PurposeRepository(DbContext context)
            : base(context)
        {

        }
        public Purpose GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
