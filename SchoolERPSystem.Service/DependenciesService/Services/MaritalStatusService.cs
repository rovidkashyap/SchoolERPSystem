using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Repositories
{
    public class MaritalStatusService : EntityService<MaritalStatus>, IMaritalStatusService
    {
        IUnitOfWork _unitOfWork;
        IMaritalStatusRepository _maritalrepository;

        public MaritalStatusService(IUnitOfWork unitofwork, IMaritalStatusRepository maritalrepository)
            : base(unitofwork, maritalrepository)
        {
            _unitOfWork = unitofwork;
            _maritalrepository = maritalrepository;
        }

        public MaritalStatus GetById(int Id)
        {
            return _maritalrepository.GetById(Id);
        }
    }
}
