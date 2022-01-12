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
    public class ItemStockService : EntityService<ItemStock>, IItemStockService
    {
        IUnitOfWork _unitOfWork;
        IItemStockRepository _itemStockRepository;

        public ItemStockService(IUnitOfWork unitOfWork, IItemStockRepository itemStockRepository)
            : base(unitOfWork, itemStockRepository)
        {
            _unitOfWork = unitOfWork;
            _itemStockRepository = itemStockRepository;
        }

        public ItemStock GetById(int id)
        {
            return _itemStockRepository.GetById(id);
        }
    }
}
