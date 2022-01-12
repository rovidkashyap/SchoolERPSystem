using SchoolERPSystem.Models.Setting;
using SchoolERPSystem.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.DependenciesRepository.Interfaces.GeneralSettingInterfaces
{
    public interface IGeneralSettingRepository : IGenericRepository<GeneralSetting>
    {
        GeneralSetting GetById(int id);
    }
}
