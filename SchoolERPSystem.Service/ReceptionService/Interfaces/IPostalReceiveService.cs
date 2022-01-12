﻿using SchoolERPSystem.Models.Reception;
using SchoolERPSystem.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Service.ReceptionService.Interfaces
{
    public interface IPostalReceiveService : IEntityService<PostalReceive>
    {
        PostalReceive GetById(int id);
    }
}