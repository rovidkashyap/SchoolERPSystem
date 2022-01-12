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
    public class StaffAttendanceService : EntityService<StaffAttendance>, IStaffAttendanceService
    {
        IUnitOfWork _unitOfWork;
        IStaffAttendanceRepository _staffAttendance;

        public StaffAttendanceService(IUnitOfWork unitOfWork, IStaffAttendanceRepository staffAttendanceRepository)
            : base(unitOfWork, staffAttendanceRepository)
        {
            _unitOfWork = unitOfWork;
            _staffAttendance = staffAttendanceRepository;
        }

        public StaffAttendance GetById(int id)
        {
            return _staffAttendance.GetById(id);
        }

    }
}
