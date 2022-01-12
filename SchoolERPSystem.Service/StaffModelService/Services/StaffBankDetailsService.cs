using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StaffModelRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.StaffModelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StaffModelService.Services
{
    public class StaffBankDetailsService : EntityService<StaffBankDetails>, IStaffBankDetailsService
    {
        IUnitOfWork _unitOfWork;
        IStaffBankDetailsRepository _staffBankDetailsRepository;

        public StaffBankDetailsService(IUnitOfWork unitofwork, IStaffBankDetailsRepository staffBankDetailsRepository)
            : base(unitofwork, staffBankDetailsRepository)
        {
            _unitOfWork = unitofwork;
            _staffBankDetailsRepository = staffBankDetailsRepository;
        }

        public StaffBankDetails GetById(string id)
        {
            return _staffBankDetailsRepository.GetById(id);
        }
    }
}
