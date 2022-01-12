﻿using SchoolERPSystem.Models.Dependencies.StudentDependencies;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.DependenciesService.Interfaces.StudentInterfaces
{
    public interface IBloodGroupService : IEntityService<BloodGroup>
    {
        BloodGroup GetById(int id);
    }
}
