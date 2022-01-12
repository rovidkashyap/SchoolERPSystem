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
    public class HostelRoomService : EntityService<HostelRoom>, IHostelRoomService
    {
        IUnitOfWork _unitOfWork;
        IHostelRoomRepository _hostelRoomRepository;

        public HostelRoomService(IUnitOfWork unitOfWork, IHostelRoomRepository hostelRoomRepository)
            : base(unitOfWork, hostelRoomRepository)
        {
            _unitOfWork = unitOfWork;
            _hostelRoomRepository = hostelRoomRepository;
        }

        public HostelRoom GetById(int id)
        {
            return _hostelRoomRepository.GetById(id);
        }
    }
}
