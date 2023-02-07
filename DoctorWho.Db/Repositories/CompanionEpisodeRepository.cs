using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public class CompanionEpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();

        public int AddExistCompanionToNewEpisode()
        {
            Episode episode = new Episode()
            {
                EpisodeNumber = 1,
                SeriesNumber = 2,
                EpisodeType = "Action",
                Title = "Death",
                EpisodeDate = DateTime.Now,
                AuthorId = 1005,
                DoctorId = 205
            };

            var companion = context.Companions.FirstOrDefault(x => x.CompanionName == "Polly");
            if (companion != null)
                episode.Companions.Add(companion);
            context.Episodes.Add(episode);
            return context.SaveChanges();
        }

        public int AddCompanionToExistEpisode()
        {
            var episode = context.Episodes.Find(302);
            if (episode != null)
                episode.Companions.Add(new Companion()
                {
                    CompanionName = "XCompanion",
                    WhoPlayed = "YPerson"
                });
            return context.SaveChanges();
        }
    }
}
