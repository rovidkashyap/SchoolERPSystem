using SchoolERPSystem.Models.Hostel;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.HostelService.Interfaces
{
    public interface IHostelService : IEntityService<Hostel>
    {
        Hostel GetById(int id);
    }
}
