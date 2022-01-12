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
    public class HostelService : EntityService<Hostel>, IHostelService
    {
        IUnitOfWork _unitOfWork;
        IHostelRepository _hostelRepository;

        public HostelService(IUnitOfWork unitOfWork, IHostelRepository hostelRepository)
            : base(unitOfWork, hostelRepository)
        {
            _unitOfWork = unitOfWork;
            _hostelRepository = hostelRepository;
        }

        public Hostel GetById(int id)
        {
            return _hostelRepository.GetById(id);
        }
    }
}
