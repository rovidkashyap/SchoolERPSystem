using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.HostelRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.HostelRepository.Repositories
{
    public class HostelTypeRepository : GenericRepository<HostelType>, IHostelTypeRepository
    {
        public HostelTypeRepository(DbContext context)
            : base(context)
        {

        }

        public HostelType GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
