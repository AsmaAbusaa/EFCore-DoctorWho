using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    internal class CompanionRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddCompanion()
        {
            Companion companion = new Companion()
            {
                CompanionName = "Polly",
                WhoPlayed = "Alex"
            };
            var returnValue = context.Companions.Add(companion);
            context.SaveChanges();
        }
        public void DeleteCompanion(int id)
        {
            var result = context.Companions.FromSqlInterpolated($"DELETE FROM Companions WHERE CompanionId={id}");
            context.SaveChanges();
        }
        public Companion GetCompanionById(int id)
        {
            var companion = context.Companions.Find(id);
            if (companion != null)
                return companion;
            throw new Exception("Not Found");

        }
        public void UpdateCompanionName(int id, string newName)
        {
            var companion = context.Companions.Find(id);
            if (companion != null)
                companion.CompanionName = newName;
            context.SaveChanges();
        }

    }
}
