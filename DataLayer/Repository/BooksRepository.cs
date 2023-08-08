using Datalayer.Repository.IRepository;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace Datalayer.Repository
{
    public class BooksRepository : Repository<Books>, IBooksRepository
    {
        private readonly Library_DbEntities _db;
        public BooksRepository(Library_DbEntities db) : base(db)
        {
            _db = db;
        }

        public void Update(Books book)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Id == book.Id);
            objFromDb.BookName = book.BookName;
            objFromDb.Category = book.Category;
            objFromDb.Price = book.Price;
            objFromDb.Count = book.Count;
            objFromDb.Likes = book.Likes;
            objFromDb.Scores = book.Scores;
            objFromDb.isSpecial = book.isSpecial;
            objFromDb.Date = book.Date;
            objFromDb.Image = book.Image;
        }
    }
}
