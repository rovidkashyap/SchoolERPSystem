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
    public class DepartmentService : EntityService<Department>, IDepartmentService
    {
        IUnitOfWork _unitofwork;
        IDepartmentRepository _departmentRepository;

        public DepartmentService(IUnitOfWork unitofwork, IDepartmentRepository departmentrepository)
            : base(unitofwork, departmentrepository)
        {
            _unitofwork = unitofwork;
            _departmentRepository = departmentrepository;
        }

        public Department GetById(int id)
        {
            return _departmentRepository.GetById(id);
        }
    }
}
