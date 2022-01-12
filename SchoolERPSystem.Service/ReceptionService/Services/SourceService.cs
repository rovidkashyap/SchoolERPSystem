using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ReceptionRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ReceptionService.Services
{
    public class SourceService : EntityService<Source>, ISourceService
    {
        IUnitOfWork _unitOfWork;
        ISourceRepository _sourceRepository;

        public SourceService(IUnitOfWork unitOfWork, ISourceRepository sourceRepository)
            : base(unitOfWork, sourceRepository)
        {
            _unitOfWork = unitOfWork;
            _sourceRepository = sourceRepository;
        }

        public Source GetById(int id)
        {
            return _sourceRepository.GetById(id);
        }
    }
}
