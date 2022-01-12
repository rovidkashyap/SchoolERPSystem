using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ReceptionService.Interfaces
{
    public interface IComplaintService : IEntityService<ComplainDetails>
    {
        ComplainDetails GetById(int id);
    }
}
