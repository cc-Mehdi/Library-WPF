
using System;
using System.Linq.Expressions;

namespace Datalayer.Repository.IRepository
{
    public interface IBooksRepository : IRepository<Books>
    {
        void Update(Books book);
        void Filter(Expression<Func<Books, bool>> filter = null);
    }
}
