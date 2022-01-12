using SchoolERPSystem.Models.Income;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.IncomeRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.IncomeService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.IncomeService.Services
{
    public class IncomeService : EntityService<Income>, IIncomeService
    {
        IUnitOfWork _unitOfWork;
        IIncomeRepository _incomeRepository;

        public IncomeService(IUnitOfWork unitOfWork, IIncomeRepository incomeRepository)
            : base(unitOfWork, incomeRepository)
        {
            _unitOfWork = unitOfWork;
            _incomeRepository = incomeRepository;
        }

        public Income GetById(int id)
        {
            return _incomeRepository.GetById(id);
        }
    }
}
