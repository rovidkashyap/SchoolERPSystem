using SchoolERPSystem.Models.Setting;
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
    public class GeneralSettingService : EntityService<GeneralSetting>, IGeneralSettingService
    {
        IUnitOfWork _unitofWork;
        IGeneralSettingRepository _GeneralSettingRepository;

        public GeneralSettingService(IUnitOfWork unitOfWork, IGeneralSettingRepository GeneralSettingRepository)
            : base(unitOfWork, GeneralSettingRepository)
        {
            _unitofWork = unitOfWork;
            _GeneralSettingRepository = GeneralSettingRepository;
        }

        public GeneralSetting GetById(int Id)
        {
            return _GeneralSettingRepository.GetById(Id);
        }
    }
}
