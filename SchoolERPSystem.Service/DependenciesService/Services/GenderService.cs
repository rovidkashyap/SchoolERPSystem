using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces;
using SchoolERPSystem.Repository.DependenciesRepository.Repositories;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Repositories
{
    public class GenderService : EntityService<Gender>, IGenderService
    {
        IUnitOfWork _unitofWork;
        IGenderRepository _genderRepository;

        public GenderService(IUnitOfWork unitOfWork, IGenderRepository genderRepository)
            : base(unitOfWork, genderRepository)
        {
            _unitofWork = unitOfWork;
            _genderRepository = genderRepository;
        }

        public Gender GetById(int Id)
        {
            return _genderRepository.GetById(Id);
        }
    }
}
