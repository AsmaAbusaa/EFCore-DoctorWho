using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public class EpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddEpisode(int episodeNumber,string type,
                              DateTime episodeDate,string title,int authorId,int doctorId,int sereiesNumber)
        {
            context.Episodes.Add(
               new Episode
               {
                   EpisodeType = type,
                   EpisodeDate = episodeDate,
                   EpisodeNumber = episodeNumber,
                   AuthorId = authorId,
                   DoctorId = doctorId,
                   Title = title,
                   SeriesNumber =sereiesNumber
               });
            return context.SaveChanges();   
        }
        
        public int AddEpisode(Episode episode)
        {
            context.Episodes.Add(episode);
            return context.SaveChanges();
        }
        public int DeleteEpisode(int id)
        {
            var episode = context.Episodes.Find(id);
            if (episode != null)
                context.Episodes.Remove(episode);
          
            return context.SaveChanges();    
        }
        public int UpdateEpisode(Episode episode)
        {
           context.Update(episode);
            return context.SaveChanges();
        }
    }
}
