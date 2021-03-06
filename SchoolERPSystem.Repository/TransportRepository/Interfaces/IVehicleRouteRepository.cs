using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.TransportRepository.Interfaces
{
    public interface IVehicleRouteRepository : IGenericRepository<VehicleRoute>
    {
        VehicleRoute GetById(int id);
    }
}
