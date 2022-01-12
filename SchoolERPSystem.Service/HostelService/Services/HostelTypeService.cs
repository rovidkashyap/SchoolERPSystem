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
    public class HostelTypeService : EntityService<HostelType>, IHostelTypeService
    {
        IUnitOfWork _unitOfWork;
        IHostelTypeRepository _hostelTypeRepository;

        public HostelTypeService(IUnitOfWork unitOfWork, IHostelTypeRepository hostelTypeRepository)
            : base(unitOfWork, hostelTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _hostelTypeRepository = hostelTypeRepository;
        }

        public HostelType GetById(int id)
        {
            return _hostelTypeRepository.GetById(id);
        }
    }
}
