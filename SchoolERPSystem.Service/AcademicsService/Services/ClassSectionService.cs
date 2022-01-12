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
    public class ClassSectionService : EntityService<ClassSection>, IClassSectionService
    {
        IUnitOfWork _unitOfWork;
        IClassSectionRepository _classSectionRepository;

        public ClassSectionService(IUnitOfWork unitOfWork, IClassSectionRepository classSectionRepository)
            : base(unitOfWork, classSectionRepository)
        {
            _unitOfWork = unitOfWork;
            _classSectionRepository = classSectionRepository;
        }

        public ClassSection GetById(int id)
        {
            return _classSectionRepository.GetById(id);
        }
    }
}
