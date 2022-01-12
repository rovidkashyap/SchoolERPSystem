using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.Inventory.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.Inventory.Repositories
{
    public class ItemCategoryRepository : GenericRepository<ItemCategory>, IItemCategoryRepository
    {
        public ItemCategoryRepository(DbContext context)
            : base(context)
        {

        }
        public ItemCategory GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
