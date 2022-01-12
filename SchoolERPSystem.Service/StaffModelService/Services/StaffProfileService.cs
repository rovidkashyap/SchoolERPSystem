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
    public class StaffProfileService : EntityService<StaffProfile>, IStaffProfileService
    {
        IUnitOfWork _unitOfWork;
        IStaffProfileRepository _staffProfileRepository;

        public StaffProfileService(IUnitOfWork unitofwork, IStaffProfileRepository staffProfileRepository)
            : base(unitofwork, staffProfileRepository)
        {
            _unitOfWork = unitofwork;
            _staffProfileRepository = staffProfileRepository;
        }

        public StaffProfile GetById(int? id)
        {
            return _staffProfileRepository.GetById(id.Value);
        }

        public StaffProfile GetById(string id)
        {
            return _staffProfileRepository.GetById(id);
        }

        public int GetCountByRoleName(string rolename)
        {
            return _staffProfileRepository.GetCountByRoleName(rolename);
        }
    }
}
