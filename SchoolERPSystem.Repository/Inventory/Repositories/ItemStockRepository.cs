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
    public class ItemStockRepository : GenericRepository<ItemStock>, IItemStockRepository
    {
        public ItemStockRepository(DbContext context)
            : base(context)
        {

        }

        public ItemStock GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
