
namespace Datalayer.Repository.IRepository
{
    public interface IBorrowedBooksRepository : IRepository<BorrowedBooks>
    {
        void Update(BorrowedBooks borrowedBooks);
    }
}
