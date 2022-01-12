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
    public class PostalReceiveService : EntityService<PostalReceive>, IPostalReceiveService
    {
        IUnitOfWork _unitOfWork;
        IPostalReceiveRepository _PostalReceiveRepository;

        public PostalReceiveService(IUnitOfWork unitOfWork, IPostalReceiveRepository PostalReceiveRepository)
            : base(unitOfWork, PostalReceiveRepository)
        {
            _unitOfWork = unitOfWork;
            _PostalReceiveRepository = PostalReceiveRepository;
        }

        public PostalReceive GetById(int id)
        {
            return _PostalReceiveRepository.GetById(id);
        }
    }
}
