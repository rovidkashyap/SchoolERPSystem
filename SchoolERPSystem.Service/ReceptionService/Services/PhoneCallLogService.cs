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
    public class PhoneCallLogService : EntityService<PhoneCallLog>, IPhoneCallLogService
    {
        IUnitOfWork _unitOfWork;
        IPhoneCallLogRepository _PhoneCallLogRepository;

        public PhoneCallLogService(IUnitOfWork unitOfWork, IPhoneCallLogRepository PhoneCallLogRepository)
            : base(unitOfWork, PhoneCallLogRepository)
        {
            _unitOfWork = unitOfWork;
            _PhoneCallLogRepository = PhoneCallLogRepository;
        }

        public PhoneCallLog GetById(int id)
        {
            return _PhoneCallLogRepository.GetById(id);
        }
    }
}
