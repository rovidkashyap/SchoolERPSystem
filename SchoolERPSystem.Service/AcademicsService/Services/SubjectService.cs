using SchoolERPSystem.Models.Academics;
using SchoolERPSystem.Repository.AcademicsRepository.Interfaces;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Service.AcademicsService.Interfaces;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.AcademicsService.Services
{
    public class SubjectService : EntityService<Subject>, ISubjectService
    {
        IUnitOfWork _unitOfWork;
        ISubjectRepository _subjectRepository;

        public SubjectService(IUnitOfWork unitOfWork, ISubjectRepository subjectRepository)
            : base(unitOfWork, subjectRepository)
        {
            _unitOfWork = unitOfWork;
            _subjectRepository = subjectRepository;
        }

        public Subject GetById(int id)
        {
            return _subjectRepository.GetById(id);
        }
    }
}
