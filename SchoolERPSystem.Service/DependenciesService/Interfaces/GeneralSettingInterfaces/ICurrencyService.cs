using SchoolERPSystem.Models.Dependencies.SettingDependencies;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Interfaces.GeneralSettingInterfaces
{
    public interface ICurrencyService : IEntityService<Currency>
    {
        Currency GetById(int Id);
    }
}
