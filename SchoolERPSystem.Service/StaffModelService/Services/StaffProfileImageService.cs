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
    public class StaffProfileImageService : EntityService<StaffProfileImage>, IStaffProfileImageService
    {
        IUnitOfWork _unitOfWork;
        IStaffProfileImageRepository _staffProfileImageRepository;

        public StaffProfileImageService(IUnitOfWork unitofwork, IStaffProfileImageRepository staffProfileImageRepository)
            : base(unitofwork, staffProfileImageRepository)
        {
            _unitOfWork = unitofwork;
            _staffProfileImageRepository = staffProfileImageRepository;
        }

        public StaffProfileImage GetById(string id)
        {
            return _staffProfileImageRepository.GetById(id);
        }
    }
}
