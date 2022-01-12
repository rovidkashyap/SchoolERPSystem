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
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context)
            : base(context)
        {

        }
        public Item GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
