using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class IncludeService<T1, T2>
        where T1 : class
        where T2 : class
    {
        public List<T1> includedEntity;
        public IncludeService(IQueryable<T1> entity, Expression<Func<T1, T2>> func)
        {
            includedEntity = entity.Include(func).ToList();
        }
    }
}