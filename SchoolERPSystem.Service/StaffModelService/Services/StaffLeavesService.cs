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
    public class StaffLeavesService : EntityService<StaffLeaves>, IStaffLeavesService
    {
        IUnitOfWork _unitOfWork;
        IStaffLeavesRepository _staffLeavesRepository;

        public StaffLeavesService(IUnitOfWork unitofwork, IStaffLeavesRepository staffLeavesRepository)
            : base(unitofwork, staffLeavesRepository)
        {
            _unitOfWork = unitofwork;
            _staffLeavesRepository = staffLeavesRepository;
        }

        public StaffLeaves GetById(string id)
        {
            return _staffLeavesRepository.GetById(id);
        }
    }
}
