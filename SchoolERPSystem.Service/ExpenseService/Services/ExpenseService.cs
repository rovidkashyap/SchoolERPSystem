using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ExpenseRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.ExpenseService.Interfaces;

namespace SchoolERPSystem.Service.ExpenseService.Services
{
    public class ExpenseService : EntityService<Expense>, IExpenseService
    {
        IUnitOfWork _unitOfWork;
        IExpensesRepository _expenseRepository;

        public ExpenseService(IUnitOfWork unitOfWork, IExpensesRepository expenseRepository)
            : base(unitOfWork, expenseRepository)
        {
            _unitOfWork = unitOfWork;
            _expenseRepository = expenseRepository;
        }

        public Expense GetById(int id)
        {
            return _expenseRepository.GetById(id);
        }
    }
}
