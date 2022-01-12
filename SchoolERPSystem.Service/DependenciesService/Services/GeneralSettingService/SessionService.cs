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
    public class SessionService : EntityService<Session>, ISessionService
    {
        IUnitOfWork _unitofWork;
        ISessionRepository _sessionRepository;

        public SessionService(IUnitOfWork unitofWork, ISessionRepository sessionRepository)
            : base(unitofWork, sessionRepository)
        {
            _unitofWork = unitofWork;
            _sessionRepository = sessionRepository;
        }

        public Session GetById(int Id)
        {
            return _sessionRepository.GetById(Id);
        }
    }
}
