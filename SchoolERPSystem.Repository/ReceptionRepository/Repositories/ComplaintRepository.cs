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
    public class ComplaintRepository : GenericRepository<ComplainDetails>, IComplaintRepository
    {
        public ComplaintRepository(DbContext context)
            : base(context)
        {

        }

        public ComplainDetails GetById(int Id)
        {
            return FindBy(c => c.Id == Id).FirstOrDefault();
        }
    }
}
