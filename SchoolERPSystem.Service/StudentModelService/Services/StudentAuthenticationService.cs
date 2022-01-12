using SchoolERPSystem.Models.Authentication;
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
    public class StudentAuthenticationService : EntityService<StudentAuthentication>, IStudentAuthenticationService
    {
        IUnitOfWork _unitOfWork;
        IStudentAuthenticationRepository _studentAuthenticationRepository;

        public StudentAuthenticationService(IUnitOfWork unitOfWork, IStudentAuthenticationRepository studentAuthenticationRepository)
            : base(unitOfWork, studentAuthenticationRepository)
        {
            _unitOfWork = unitOfWork;
            _studentAuthenticationRepository = studentAuthenticationRepository;
        }

        public StudentAuthentication GetById(int id)
        {
            return _studentAuthenticationRepository.GetById(id);
        }
    }
}
