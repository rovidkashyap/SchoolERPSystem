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
    public class StudentDocumentService : EntityService<StudentDocument>, IStudentDocumentService
    {
        IUnitOfWork _unitOfWork;
        IStudentDocumentRepository _studentDocumentRepository;

        public StudentDocumentService(IUnitOfWork unitOfWork, IStudentDocumentRepository studentDocumentRepository)
            : base(unitOfWork, studentDocumentRepository)
        {
            _unitOfWork = unitOfWork;
            _studentDocumentRepository = studentDocumentRepository;
        }

        public StudentDocument GetById(int id)
        {
            return _studentDocumentRepository.GetById(id);
        }
    }
}
