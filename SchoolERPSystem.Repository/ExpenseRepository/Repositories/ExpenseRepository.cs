using SchoolERPSystem.Models.Expense;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ExpenseRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.ExpenseRepository.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpensesRepository
    {
        public ExpenseRepository(DbContext context)
            : base(context)
        {

        }
        public Expense GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
