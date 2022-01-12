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
    public class RoomTypeRepository : GenericRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(DbContext context)
            : base(context)
        {

        }

        public RoomType GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
