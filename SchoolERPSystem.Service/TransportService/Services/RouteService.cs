using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.TransportRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.TransportService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.TransportService.Services
{
    public class RouteService : EntityService<Route>, IRouteService
    {
        IUnitOfWork _unitOfWork;
        IRouteRepository _routeRepository;

        public RouteService(IUnitOfWork unitOfWork, IRouteRepository routeRepository)
            : base(unitOfWork, routeRepository)
        {
            _unitOfWork = unitOfWork;
            _routeRepository = routeRepository;
        }

        public Route GetById(int id)
        {
            return _routeRepository.GetById(id);
        }
    }
}
