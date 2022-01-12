using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces.StudentInterfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Services.StudentService
{
    public class BloodGroupService : EntityService<BloodGroup>, IBloodGroupService
    {
        IUnitOfWork _unitOfWork;
        IBloodGroupRepository _bloodGroupRepository;

        public BloodGroupService(IUnitOfWork unitOfWork, IBloodGroupRepository bloodGroupRepository)
            : base(unitOfWork, bloodGroupRepository)
        {
            _unitOfWork = unitOfWork;
            _bloodGroupRepository = bloodGroupRepository;
        }

        public BloodGroup GetById(int id)
        {
            return _bloodGroupRepository.GetById(id);
        }
    }
}
