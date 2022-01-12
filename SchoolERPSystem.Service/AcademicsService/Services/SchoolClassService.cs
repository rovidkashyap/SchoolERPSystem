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
    public class SchoolClassService : EntityService<SchoolClass>, ISchoolClassService
    {
        IUnitOfWork _unitOfWork;
        ISchoolClassRepository _schoolClassRepository;

        public SchoolClassService(IUnitOfWork unitOfWork, ISchoolClassRepository schoolClassRepository)
            : base(unitOfWork, schoolClassRepository)
        {
            _unitOfWork = unitOfWork;
            _schoolClassRepository = schoolClassRepository;
        }

        public SchoolClass GetById(int id)
        {
            return _schoolClassRepository.GetById(id);
        }
    }
}
