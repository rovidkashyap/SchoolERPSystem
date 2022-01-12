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
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbContext context)
            : base(context)
        {

        }
        public Currency GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
