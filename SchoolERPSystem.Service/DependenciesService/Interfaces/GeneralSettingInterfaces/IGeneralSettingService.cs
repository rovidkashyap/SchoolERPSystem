using SchoolERPSystem.Models.Setting;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Interfaces.GeneralSettingInterfaces
{
    public interface IGeneralSettingService : IEntityService<GeneralSetting>
    {
        GeneralSetting GetById(int Id);
    }
}
