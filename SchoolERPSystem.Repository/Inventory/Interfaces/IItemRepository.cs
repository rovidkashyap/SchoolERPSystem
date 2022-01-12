using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.Inventory.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        Item GetById(int id);
    }
}
