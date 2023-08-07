using System;

namespace Datalayer.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository User { get; }
        IBooksRepository Book { get; }
        IBorrowedBooksRepository BorrowedBook { get; }
        void Save();
    }
}
