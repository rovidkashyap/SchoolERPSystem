using SchoolERPSystem.Models.Dependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Repositories
{
    public class DesignationService : EntityService<Designation>, IDesignationService
    {
        IUnitOfWork _unitofwork;
        IDesignationRepository _designationrepository;

        public DesignationService(IUnitOfWork unitofwork, IDesignationRepository designationrepository)
            : base(unitofwork, designationrepository)
        {
            _unitofwork = unitofwork;
            _designationrepository = designationrepository;
        }

        public Designation GetById(int id)
        {
            return _designationrepository.GetById(id);
        }
    }
}
