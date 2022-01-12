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
    public class PostalDispatchService : EntityService<PostalDispatch>, IPostalDispatchService
    {
        IUnitOfWork _unitOfWork;
        IPostalDispatchRepository _PostalDispatchRepository;

        public PostalDispatchService(IUnitOfWork unitOfWork, IPostalDispatchRepository PostalDispatchRepository)
            : base(unitOfWork, PostalDispatchRepository)
        {
            _unitOfWork = unitOfWork;
            _PostalDispatchRepository = PostalDispatchRepository;
        }

        public PostalDispatch GetById(int id)
        {
            return _PostalDispatchRepository.GetById(id);
        }
    }
}
