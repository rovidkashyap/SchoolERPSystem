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
    public class ItemCategoryService : EntityService<ItemCategory>, IItemCategoryService
    {
        IUnitOfWork _unitOfWork;
        IItemCategoryRepository _itemCategoryRepository;

        public ItemCategoryService(IUnitOfWork unitOfWork, IItemCategoryRepository itemCategoryRepository)
            : base(unitOfWork, itemCategoryRepository)
        {
            _unitOfWork = unitOfWork;
            _itemCategoryRepository = itemCategoryRepository;
        }

        public ItemCategory GetById(int id)
        {
            return _itemCategoryRepository.GetById(id);
        }
    }
}
