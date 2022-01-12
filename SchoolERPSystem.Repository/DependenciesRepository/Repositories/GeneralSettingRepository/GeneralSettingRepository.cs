using SchoolERPSystem.Models.Setting;
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
    public class GeneralSettingRepository : GenericRepository<GeneralSetting>, IGeneralSettingRepository
    {
        public GeneralSettingRepository(DbContext context)
            : base(context)
        {

        }

        public GeneralSetting GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
