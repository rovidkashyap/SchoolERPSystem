using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces.GeneralSettingInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Repositories.GeneralSettingRepository
{
    public class TimezoneRepository : GenericRepository<Timezone>, ITimezoneRepository
    {
        public TimezoneRepository(DbContext context)
            : base(context)
        {

        }

        public Timezone GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
