
namespace Datalayer.Repository.IRepository
{
    public interface IBooksRepository : IRepository<Books>
    {
        void Update(Books book);
    }
}
