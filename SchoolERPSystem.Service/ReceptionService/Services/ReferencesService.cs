using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.ReceptionRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.ReceptionService.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ReceptionService.Services
{
    public class ReferencesService : EntityService<Reference>, IReferencesService
    {
        IUnitOfWork _unitOfWork;
        IReferenceRepository _referenceRepository;

        public ReferencesService(IUnitOfWork unitOfWork, IReferenceRepository referenceRepository)
            : base(unitOfWork, referenceRepository)
        {
            _unitOfWork = unitOfWork;
            _referenceRepository = referenceRepository;
        }

        public Reference GetById(int id)
        {
            return _referenceRepository.GetById(id);
        }
    }
}
