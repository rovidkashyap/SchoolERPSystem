using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.ReceptionRepository.Interfaces
{
    public interface IComplaintRepository : IGenericRepository<ComplainDetails>
    {
        ComplainDetails GetById(int Id);
    }
}
