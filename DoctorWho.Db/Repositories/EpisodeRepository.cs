using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddEpisode()
        {
            context.Episodes.Add(
               new Episode
               {
                   EpisodeType = "Action",
                   EpisodeDate = DateTime.Now,
                   EpisodeNumber = 7,
                   AuthorId = 1000,
                   DoctorId = 205,
                   Title = "LIFE",
                   SeriesNumber = 8
               });
            var result = context.SaveChanges();
            return result;
        }
        public int DeleteEpisode(int id)
        {
            var episode = context.Episodes.Find(id);
            if (episode != null)
                context.Episodes.Remove(episode);
            else throw new Exception("Not Found");
            var result = context.SaveChanges();
            return result;
        }
        public int UpdateEpisodeTypeToCanceld(int id)
        {
            var episode = context.Episodes.Find(id);
            if (episode != null)
                episode.EpisodeType = "Canceld";
            var result = context.SaveChanges();
            return result;
        }
    }
}
