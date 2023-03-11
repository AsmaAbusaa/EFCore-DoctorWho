using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    internal class CompanionRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddCompanion(string companionName,string whoPlayed)
        {
            Companion companion = new Companion()
            {
                CompanionName = companionName,
                WhoPlayed = whoPlayed
            };
            var returnValue = context.Companions.Add(companion);
            return context.SaveChanges();
        }
        public int DeleteCompanion(int id)
        {
            var result = context.Companions.FromSqlInterpolated($"DELETE FROM Companions WHERE CompanionId={id}");
           return context.SaveChanges();
        }
        public Companion GetCompanionById(int id)
        {
            var companion = context.Companions.Find(id);
            if (companion != null)
                return companion;
            throw new Exception("Not Found");

        }
        public int UpdateCompanion(int id, string newName,string newActor)
        {
            var companion = context.Companions.Find(id);
            if (companion != null)
            {
                companion.CompanionName = newName;
                companion.WhoPlayed = newActor;
            }
          return  context.SaveChanges();
        }

    }
}
