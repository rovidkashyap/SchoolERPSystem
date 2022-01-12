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
    public class TimezoneService : EntityService<Timezone>, ITimezoneService
    {
        IUnitOfWork _unitofWork;
        ITimezoneRepository _TimezoneRepository;

        public TimezoneService(IUnitOfWork unitofWork, ITimezoneRepository timezoneRepository)
            : base(unitofWork, timezoneRepository)
        {
            _unitofWork = unitofWork;
            _TimezoneRepository = timezoneRepository;
        }

        public Timezone GetById(int Id)
        {
            return _TimezoneRepository.GetById(Id);
        }
    }
}
