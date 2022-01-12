using SchoolERPSystem.Models.StaffModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StaffModelRepository.Interfaces;
using SchoolERPSystem.Service.Common;
using SchoolERPSystem.Service.StaffModelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StaffModelService.Services
{
    class StaffDocumentsService : EntityService<StaffDocuments>, IStaffDocumentsService
    {
        IUnitOfWork _unitOfWork;
        IStaffDocumentsRepository _staffDocumentsRepository;

        public StaffDocumentsService(IUnitOfWork unitofwork, IStaffDocumentsRepository staffDocumentsRepository)
            : base(unitofwork, staffDocumentsRepository)
        {
            _unitOfWork = unitofwork;
            _staffDocumentsRepository = staffDocumentsRepository;
        }

        public StaffDocuments GetById(string id)
        {
            return _staffDocumentsRepository.GetById(id);
        }
    }
}
