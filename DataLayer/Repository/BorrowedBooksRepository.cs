using Datalayer.Repository.IRepository;
using System.Linq;

namespace Datalayer.Repository
{
    public class BorrowedBooksRepository : Repository<BorrowedBooks>, IBorrowedBooksRepository
    {
        private readonly Library_DbEntities _db;
        public BorrowedBooksRepository(Library_DbEntities db) : base(db)
        {
            _db = db;
        }

        public void Update(BorrowedBooks borrowedBooks)
        {
            var objFromDb = _db.BorrowedBooks.FirstOrDefault(u => u.Id == borrowedBooks.Id);
            objFromDb.BookId = borrowedBooks.BookId;
            objFromDb.UserId = borrowedBooks.UserId;
            objFromDb.StartDate = borrowedBooks.StartDate;
            objFromDb.EndDate = borrowedBooks.EndDate;
        }
    }
}
