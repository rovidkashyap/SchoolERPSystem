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
    public class PurposeService : EntityService<Purpose>, IPurposeService
    {
        IUnitOfWork _unitOfWork;
        IPurposeRepository _purposeRepository;

        public PurposeService(IUnitOfWork unitOfWork, IPurposeRepository purposeRepository)
            : base (unitOfWork, purposeRepository)
        {
            _unitOfWork = unitOfWork;
            _purposeRepository = purposeRepository;
        }

        public Purpose GetById(int id)
        {
            return _purposeRepository.GetById(id);
        }
    }
}
