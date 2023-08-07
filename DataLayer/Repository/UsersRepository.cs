using Datalayer.Repository.IRepository;
using System.Linq;

namespace Datalayer.Repository
{
    public class UsersRepository : Repository<Users>, IUsersRepository
    {
        private readonly Library_DbEntities _db;
        public UsersRepository(Library_DbEntities db) : base(db)
        {
            _db = db;
        }

        public void Update(Users user)
        {
            var objFromDb = _db.Users.FirstOrDefault(u => u.Id == user.Id);
            objFromDb.UserName = user.UserName;
            objFromDb.Email = user.Email;
            objFromDb.Password = user.Password;
            objFromDb.isSpecial = user.isSpecial;
            objFromDb.Image = user.Image;
        }
    }
}
