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
    public class SectionService : EntityService<Section>, ISectionService
    {
        IUnitOfWork _unitOfWork;
        ISectionRepository _sectionRepository;

        public SectionService(IUnitOfWork unitOfWork, ISectionRepository sectionRepository)
            : base(unitOfWork, sectionRepository)
        {
            _unitOfWork = unitOfWork;
            _sectionRepository = sectionRepository;
        }

        public Section GetById(int id)
        {
            return _sectionRepository.GetById(id);
        }
    }
}
