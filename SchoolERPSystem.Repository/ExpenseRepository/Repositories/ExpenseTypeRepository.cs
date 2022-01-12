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
    public class ExpenseTypeRepository : GenericRepository<ExpenseType>, IExpenseTypeRepository
    {
        public ExpenseTypeRepository(DbContext context)
            : base(context)
        {

        }
        public ExpenseType GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
