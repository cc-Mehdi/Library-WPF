
namespace Datalayer.Repository.IRepository
{
    public interface IBooksRepository : IRepository<Users>
    {
        void Update(Books book);
    }
}
