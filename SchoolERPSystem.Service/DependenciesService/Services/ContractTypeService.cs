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

namespace SchoolERPSystem.Service.DependenciesService.Services
{
    public class ContractTypeService : EntityService<ContractType>, IContractTypeService
    {
        IUnitOfWork _unitofWork;
        IContractTypeRepository _contractTypeRepository;

        public ContractTypeService(IUnitOfWork unitOfWork, IContractTypeRepository contractTypeRepository)
            : base(unitOfWork, contractTypeRepository)
        {
            _unitofWork = unitOfWork;
            _contractTypeRepository = contractTypeRepository;
        }

        public ContractType GetById(int Id)
        {
            return _contractTypeRepository.GetById(Id);
        }
    }
}
