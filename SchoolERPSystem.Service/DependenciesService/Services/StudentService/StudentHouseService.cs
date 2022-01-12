using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.DependenciesRepository.Interfaces.StudentInterfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.DependenciesService.Interfaces.StudentInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Services.StudentService
{
    public class StudentHouseService : EntityService<StudentHouse>, IStudentHouseService
    {
        IUnitOfWork _unitOfWork;
        IStudentHouseRepository _studentHouseRepository;

        public StudentHouseService(IUnitOfWork unitOfWork, IStudentHouseRepository studentHouseRepository)
            : base(unitOfWork, studentHouseRepository)
        {
            _unitOfWork = unitOfWork;
            _studentHouseRepository = studentHouseRepository;
        }

        public StudentHouse GetById(int id)
        {
            return _studentHouseRepository.GetById(id);
        }
    }
}
