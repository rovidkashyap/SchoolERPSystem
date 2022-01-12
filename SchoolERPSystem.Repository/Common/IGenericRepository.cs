﻿using SchoolERPSystem.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolERPSystem.Repository.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);

        T Add(T entity);

        T Delete(T entity);

        void Edit(T entity);

        void Save();
    }
}
