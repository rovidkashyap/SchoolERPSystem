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
    public class ItemSupplierService : EntityService<ItemSupplier>, IItemSupplierService
    {
        IUnitOfWork _unitOfWork;
        IItemSupplierRepository _itemSupplierRepository;

        public ItemSupplierService(IUnitOfWork unitOfWork, IItemSupplierRepository itemSupplierRepository)
            : base(unitOfWork, itemSupplierRepository)
        {
            _unitOfWork = unitOfWork;
            _itemSupplierRepository = itemSupplierRepository;
        }

        public ItemSupplier GetById(int id)
        {
            return _itemSupplierRepository.GetById(id);
        }
    }
}
