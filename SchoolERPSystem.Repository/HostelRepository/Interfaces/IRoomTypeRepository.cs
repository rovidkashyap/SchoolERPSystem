using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.HostelRepository.Interfaces
{
    public interface IRoomTypeRepository : IGenericRepository<RoomType>
    {
        RoomType GetById(int id);
    }
}
