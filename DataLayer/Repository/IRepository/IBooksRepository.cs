
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Datalayer.Repository.IRepository
{
    public interface IBooksRepository : IRepository<Books>
    {
        void Update(Books book);
    }
}
