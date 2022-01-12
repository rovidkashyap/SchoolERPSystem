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
    public class ItemStoreService : EntityService<ItemStore>, IItemStoreService
    {
        IUnitOfWork _unitOfWork;
        IItemStoreRepository _itemStoreRepository;

        public ItemStoreService(IUnitOfWork unitOfWork, IItemStoreRepository itemStoreRepository)
            : base(unitOfWork, itemStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _itemStoreRepository = itemStoreRepository;
        }

        public ItemStore GetById(int id)
        {
            return _itemStoreRepository.GetById(id);
        }
    }
}
