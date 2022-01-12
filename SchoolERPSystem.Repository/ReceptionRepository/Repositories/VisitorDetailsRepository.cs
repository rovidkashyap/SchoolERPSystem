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
    public class VisitorDetailsRepository : GenericRepository<VisitorDetails>, IVisitorDetailsRepository
    {
        public VisitorDetailsRepository(DbContext context)
            : base(context)
        {

        }

        public VisitorDetails GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
