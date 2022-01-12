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
    public class PhoneCallLogRepository : GenericRepository<PhoneCallLog>, IPhoneCallLogRepository
    {
        public PhoneCallLogRepository(DbContext context)
            : base(context)
        {

        }
        public PhoneCallLog GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
