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
    public class StudentBankingService : EntityService<StudentBanking>, IStudentBankingService
    {
        IUnitOfWork _unitOfWork;
        IStudentBankingRepository _studentBankingRepository;

        public StudentBankingService(IUnitOfWork unitOfWork, IStudentBankingRepository studentBankingRepository)
            : base(unitOfWork, studentBankingRepository)
        {
            _unitOfWork = unitOfWork;
            _studentBankingRepository = studentBankingRepository;
        }

        public StudentBanking GetById(int id)
        {
            return _studentBankingRepository.GetById(id);
        }
    }
}
