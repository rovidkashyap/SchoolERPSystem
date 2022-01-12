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
    public class VehicleService : EntityService<Vehicle>, IVehicleService
    {
        IUnitOfWork _unitOfWork;
        IVehicleRepository _vehicleRepository;

        public VehicleService(IUnitOfWork unitOfWork, IVehicleRepository vehicleRepository)
            : base(unitOfWork, vehicleRepository)
        {
            _unitOfWork = unitOfWork;
            _vehicleRepository = vehicleRepository;
        }

        public Vehicle GetById(int id)
        {
            return _vehicleRepository.GetById(id);
        }
    }
}
