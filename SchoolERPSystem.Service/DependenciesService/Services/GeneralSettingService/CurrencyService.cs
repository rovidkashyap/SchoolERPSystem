using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces.GeneralSettingInterfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces.GeneralSettingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Services.GeneralSettingService
{
    public class CurrencyService : EntityService<Currency>, ICurrencyService
    {
        IUnitOfWork _unitofWork;
        ICurrencyRepository _CurrencyRepository;

        public CurrencyService(IUnitOfWork unitOfWork, ICurrencyRepository CurrencyRepository)
            : base(unitOfWork, CurrencyRepository)
        {
            _unitofWork = unitOfWork;
            _CurrencyRepository = CurrencyRepository;
        }

        public Currency GetById(int Id)
        {
            return _CurrencyRepository.GetById(Id);
        }
    }
}
