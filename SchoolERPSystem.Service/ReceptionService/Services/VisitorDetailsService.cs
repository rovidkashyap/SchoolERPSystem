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
    public class VisitorDetailsService : EntityService<VisitorDetails>, IVisitorDetailsService
    {
        IUnitOfWork _unitOfWork;
        IVisitorDetailsRepository _visitorDetailsRepository;

        public VisitorDetailsService(IUnitOfWork unitOfWork, IVisitorDetailsRepository visitorDetailsRepository)
            : base(unitOfWork, visitorDetailsRepository)
        {
            _unitOfWork = unitOfWork;
            _visitorDetailsRepository = visitorDetailsRepository;
        }

        public VisitorDetails GetById(int id)
        {
            return _visitorDetailsRepository.GetById(id);
        }
    }
}
