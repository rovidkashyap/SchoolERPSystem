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
    public class HostelRoomRepository : GenericRepository<HostelRoom>, IHostelRoomRepository
    {
        public HostelRoomRepository(DbContext context)
            : base(context)
        {

        }

        public HostelRoom GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
