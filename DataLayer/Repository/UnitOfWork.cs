using Datalayer.Repository.IRepository;

namespace Datalayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Library_DbEntities _db;
        public UnitOfWork(Library_DbEntities db)
        {
            _db = db;
            User = new UsersRepository(_db);
            Book = new BooksRepository(_db);
            BorrowedBook = new BorrowedBooksRepository(_db);
        }

        public IUsersRepository User { get; private set; }
        public IBooksRepository Book { get; private set; }
        public IBorrowedBooksRepository BorrowedBook { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
