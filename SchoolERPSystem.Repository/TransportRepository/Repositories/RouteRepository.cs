using SchoolERPSystem.Models.Transport;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.TransportRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.TransportRepository.Repositories
{
    public class RouteRepository : GenericRepository<Route>, IRouteRepository
    {
        public RouteRepository(DbContext context)
            : base(context)
        {

        }

        public Route GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
