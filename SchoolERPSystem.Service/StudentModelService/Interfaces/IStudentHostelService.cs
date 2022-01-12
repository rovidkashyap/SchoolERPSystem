﻿using SchoolERPSystem.Models.StudentModel;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.StudentModelService.Interfaces
{
    public interface IStudentHostelService : IEntityService<StudentHostel>
    {
        StudentHostel GetById(int id);
    }
}
