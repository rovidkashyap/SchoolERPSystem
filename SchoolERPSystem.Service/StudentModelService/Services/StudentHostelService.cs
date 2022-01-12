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
    public class StudentHostelService : EntityService<StudentHostel>, IStudentHostelService
    {
        IUnitOfWork _unitOfWork;
        IStudentHostelRepository _studentHostelRepository;

        public StudentHostelService(IUnitOfWork unitOfWork, IStudentHostelRepository studentHostelRepository)
            : base(unitOfWork, studentHostelRepository)
        {
            _unitOfWork = unitOfWork;
            _studentHostelRepository = studentHostelRepository;
        }

        public StudentHostel GetById(int id)
        {
            return _studentHostelRepository.GetById(id);
        }
    }
}
