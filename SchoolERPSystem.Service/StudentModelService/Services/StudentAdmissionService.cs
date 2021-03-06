using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StudentModelRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.StudentModelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StudentModelService.Services
{
    public class StudentAdmissionService : EntityService<StudentAdmission>, IStudentAdmissionService
    {
        IUnitOfWork _unitOfWork;
        IStudentAdmissionRepository _studentAdmissionRepository;

        public StudentAdmissionService(IUnitOfWork unitOfWork, IStudentAdmissionRepository studentAdmissionRepository)
            : base(unitOfWork, studentAdmissionRepository)
        {
            _unitOfWork = unitOfWork;
            _studentAdmissionRepository = studentAdmissionRepository;
        }

        public StudentAdmission GetById(int id)
        {
            return _studentAdmissionRepository.GetById(id);
        }

        public int StudentCount()
        {
            return _studentAdmissionRepository.StudentCount();
        }
    }
}
