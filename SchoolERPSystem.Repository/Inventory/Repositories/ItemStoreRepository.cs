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
    public class ItemStoreRepository : GenericRepository<ItemStore>, IItemStoreRepository
    {
        public ItemStoreRepository(DbContext context)
            :base(context)
        {

        }

        public ItemStore GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
