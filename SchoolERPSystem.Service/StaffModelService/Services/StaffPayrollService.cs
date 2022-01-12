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
    public class StaffPayrollService : EntityService<StaffPayroll>, IStaffPayrollService
    {
        IUnitOfWork _unitOfWork;
        IStaffPayrollRepository _staffPayrollRepository;

        public StaffPayrollService(IUnitOfWork unitofwork, IStaffPayrollRepository staffPayrollRepository)
            : base(unitofwork, staffPayrollRepository)
        {
            _unitOfWork = unitofwork;
            _staffPayrollRepository = staffPayrollRepository;
        }

        public StaffPayroll GetById(string id)
        {
            return _staffPayrollRepository.GetById(id);
        }
    }
}
