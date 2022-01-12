using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Repository.Common;
using SchoolERPSystem.Repository.StudentModelRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.StudentModelRepository.Repositories
{
    public class StudentDocumentRepository : GenericRepository<StudentDocument>, IStudentDocumentRepository
    {
        public StudentDocumentRepository(DbContext context)
            : base(context)
        {

        }

        public override IEnumerable<StudentDocument> GetAll()
        {
            return _entities.Set<StudentDocument>().AsEnumerable();
        }

        public StudentDocument GetById(int id)
        {
            return _dbset.Where(x => x.StudentId == id).FirstOrDefault();
        }
    }
}
