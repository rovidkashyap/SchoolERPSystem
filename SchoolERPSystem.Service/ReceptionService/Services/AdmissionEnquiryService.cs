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
    public class AdmissionEnquiryService : EntityService<AdmissionEnquiry>, IAdmissionEnquiryService
    {
        IUnitOfWork _unitOfWork;
        IAdmissionEnquiryRepository _AdmissionEnquiryRepository;

        public AdmissionEnquiryService(IUnitOfWork unitOfWork, IAdmissionEnquiryRepository AdmissionEnquiryRepository)
            : base(unitOfWork, AdmissionEnquiryRepository)
        {
            _unitOfWork = unitOfWork;
            _AdmissionEnquiryRepository = AdmissionEnquiryRepository;
        }

        public AdmissionEnquiry GetById(int id)
        {
            return _AdmissionEnquiryRepository.GetById(id);
        }
    }
}
