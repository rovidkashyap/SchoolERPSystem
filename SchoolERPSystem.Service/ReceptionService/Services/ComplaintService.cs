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
    public class ComplaintService : EntityService<ComplainDetails>, IComplaintService
    {
        IUnitOfWork _unitOfWork;
        IComplaintRepository _complaintRepository;

        public ComplaintService(IUnitOfWork unitOfWork, IComplaintRepository complaintRepository)
            : base(unitOfWork, complaintRepository)
        {
            _unitOfWork = unitOfWork;
            _complaintRepository = complaintRepository;
        }

        public ComplainDetails GetById(int id)
        {
            return _complaintRepository.GetById(id);
        }
    }
}
