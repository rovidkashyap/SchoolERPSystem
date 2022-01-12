using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.TransportService.Interfaces
{
    public interface IVehicleRouteService : IEntityService<VehicleRoute>
    {
        VehicleRoute GetById(int id);
    }
}
