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
    public class VehicleRouteService : EntityService<VehicleRoute>, IVehicleRouteService
    {
        IUnitOfWork _unitOfWork;
        IVehicleRouteRepository _vehicleRouteRepository;

        public VehicleRouteService(IUnitOfWork unitOfWork, IVehicleRouteRepository vehicleRouteRepository)
            : base(unitOfWork, vehicleRouteRepository)
        {
            _unitOfWork = unitOfWork;
            _vehicleRouteRepository = vehicleRouteRepository;
        }

        public VehicleRoute GetById(int id)
        {
            return _vehicleRouteRepository.GetById(id);
        }
    }
}
