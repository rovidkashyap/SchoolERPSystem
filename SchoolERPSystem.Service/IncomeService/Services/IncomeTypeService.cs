using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.IncomeRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.IncomeService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.IncomeService.Services
{
    public class IncomeTypeService : EntityService<IncomeType>, IIncomeTypeService
    {
        IUnitOfWork _unitOfWork;
        IIncomeTypeRepository _incomeTypeRepository;

        public IncomeTypeService(IUnitOfWork unitOfWork, IIncomeTypeRepository incomeTypeRepository)
            : base(unitOfWork, incomeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _incomeTypeRepository = incomeTypeRepository;
        }

        public IncomeType GetById(int id)
        {
            return _incomeTypeRepository.GetById(id);
        }
    }
}
