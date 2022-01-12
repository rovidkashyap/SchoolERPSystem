using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.TransportService.Interfaces
{
    public interface IVehicleService : IEntityService<Vehicle>
    {
        Vehicle GetById(int id);
    }
}
