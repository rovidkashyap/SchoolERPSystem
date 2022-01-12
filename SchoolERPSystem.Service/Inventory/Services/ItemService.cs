using SchoolERPSystem.Models.Inventory;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.Inventory.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.Inventory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.Inventory.Services
{
    public class ItemService : EntityService<Item>, IItemService
    {
        IUnitOfWork _unitOfWork;
        IItemRepository _itemRepository;

        public ItemService(IUnitOfWork unitOfWork, IItemRepository itemRepository)
            : base(unitOfWork, itemRepository)
        {
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
        }

        public Item GetById(int id)
        {
            return _itemRepository.GetById(id);
        }
    }
}
