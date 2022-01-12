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
    public class StudentTransportService : EntityService<StudentTransport>, IStudentTransportService
    {
        IUnitOfWork _unitOfWork;
        IStudentTransportRepository _studentTransportRepository;

        public StudentTransportService(IUnitOfWork unitOfWork, IStudentTransportRepository studentTransportRepository)
            : base(unitOfWork, studentTransportRepository)
        {
            _unitOfWork = unitOfWork;
            _studentTransportRepository = studentTransportRepository;
        }

        public StudentTransport GetById(int id)
        {
            return _studentTransportRepository.GetById(id);
        }
    }
}
