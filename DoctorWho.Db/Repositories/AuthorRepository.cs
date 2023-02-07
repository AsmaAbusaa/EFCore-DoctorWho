using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class AuthorRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddAuthor()
        {
            Author author = new Author()
            {
                AuthorName = "Author"
            };
            var result = context.Authors.Add(author);
            context.SaveChanges();
        }

        public void UpdateAuthor()
        {
            var author = context.Authors.Find(5);
            if (author != null)
                author.AuthorName = "Alexxx";
            context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var result = context.Authors.FromSqlInterpolated($"DELETE FROM Authors WHERE AuthorId={id}");
            context.SaveChanges();
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
