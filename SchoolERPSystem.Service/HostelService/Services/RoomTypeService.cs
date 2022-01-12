using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.HostelRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.HostelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.HostelService.Services
{
    public class RoomTypeService : EntityService<RoomType>, IRoomTypeService
    {
        IUnitOfWork _unitOfWork;
        IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService(IUnitOfWork unitOfWork, IRoomTypeRepository roomTypeRepository)
            : base(unitOfWork, roomTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _roomTypeRepository = roomTypeRepository;
        }

        public RoomType GetById(int id)
        {
            return _roomTypeRepository.GetById(id);
        }
    }
}
