using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ExpenseRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.ExpenseService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ExpenseService.Services
{
    public class ExpenseTypeService : EntityService<ExpenseType>, IExpenseTypeService
    {
        IUnitOfWork _unitOfWork;
        IExpenseTypeRepository _expenseTypeRepository;

        public ExpenseTypeService(IUnitOfWork unitOfWork, IExpenseTypeRepository expenseTypeRepository)
            : base(unitOfWork, expenseTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _expenseTypeRepository = expenseTypeRepository;
        }

        public ExpenseType GetById(int id)
        {
            return _expenseTypeRepository.GetById(id);
        }
    }
}
