using SchoolERPSystem.Models.Authentication;
using SchoolERPSystem.Repository;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service
{
    public class UserlogService : EntityService<UserLog>, IUserLogService
    {
        IUnitOfWork _unitOfWork;
        IUserLogRepository _userlogRepository;


        public UserlogService(IUnitOfWork unitOfWork, IUserLogRepository userlogRepository)
            : base(unitOfWork, userlogRepository)
        {
            _unitOfWork = unitOfWork;
            _userlogRepository = userlogRepository;
        }

        public UserLog GetById(string Id)
        {
            return _userlogRepository.GetById(Id);
        }
    }
}
