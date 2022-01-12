using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ReceptionRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ReceptionService.Services
{
    public class ComplaintTypeService : EntityService<ComplainType>, IComplaintTypeService
    {
        IUnitOfWork _unitOfWork;
        IComplaintTypeRepository _complaintTypeRepository;

        public ComplaintTypeService(IUnitOfWork unitOfWork, IComplaintTypeRepository complaintTypeRepository)
            : base(unitOfWork, complaintTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _complaintTypeRepository = complaintTypeRepository;
        }

        public ComplainType GetById(int id)
        {
            return _complaintTypeRepository.GetById(id);
        }
    }
}
