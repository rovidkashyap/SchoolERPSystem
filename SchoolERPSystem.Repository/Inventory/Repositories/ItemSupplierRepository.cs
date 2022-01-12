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
    public class ItemSupplierRepository : GenericRepository<ItemSupplier>, IItemSupplierRepository
    {
        public ItemSupplierRepository(DbContext context)
            : base(context)
        {

        }
        public ItemSupplier GetById(int id)
        {
            return FindBy(i => i.Id == id).FirstOrDefault();
        }
    }
}
