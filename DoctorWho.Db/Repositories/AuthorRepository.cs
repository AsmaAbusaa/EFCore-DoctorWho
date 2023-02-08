using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddAuthor(string name)
        {
            Author author = new Author()
            {
                AuthorName = name
            };
            var result = context.Authors.Add(author);
         return context.SaveChanges();
        }

        public int UpdateAuthor(int id,string newName)
        {
            var author = context.Authors.Find(id);
            if (author != null)
                author.AuthorName = newName;
            return context.SaveChanges();
        }

        public int DeleteAuthor(int id)
        {
            var result = context.Authors.FromSqlInterpolated($"DELETE FROM Authors WHERE AuthorId={id}");
           return context.SaveChanges();
        }
        public Author GetAuthor(int id)
        {
            var author = context.Authors.Find(id);
            if (author != null)
                return author;
            throw new Exception("Not Found");
        }
    }

}
