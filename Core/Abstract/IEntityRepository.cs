using Core.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IEntityRepository<T>
    {
        T GetById(Expression<Func<T,bool>> filter );

        IList<T> GetAll(Expression<Func<T, bool>> filter = null);

        void add(T entity);

        void update(T entity);

        void delete(T entity);
    }
}
