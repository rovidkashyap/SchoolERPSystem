using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.Inventory.Interfaces
{
    public interface IItemService : IEntityService<Item>
    {
        Item GetById(int id);
    }
}
