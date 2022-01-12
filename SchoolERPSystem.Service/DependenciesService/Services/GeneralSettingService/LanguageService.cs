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
    public class LanguageService : EntityService<Language>, ILanguageService
    {
        IUnitOfWork _unitofWork;
        ILanguageRepository _LanguageRepository;

        public LanguageService(IUnitOfWork unitOfWork, ILanguageRepository LanguageRepository)
            : base(unitOfWork, LanguageRepository)
        {
            _unitofWork = unitOfWork;
            _LanguageRepository = LanguageRepository;
        }

        public Language GetById(int Id)
        {
            return _LanguageRepository.GetById(Id);
        }
    }
}
