using DoctorWho.Db.DataModels;
using System.Data.Entity;

namespace DoctorWho.Db.Repositories
{
    public class CompanionEpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddCompanionToEpisode(int companionId, int episodeId)
        {
            var episode = context.Episodes.Find(episodeId);
            var companion=context.Companions.Find(companionId);

            if (episode != null && companion!=null)
                episode.Companions.Add(companion);
            return context.SaveChanges();
        }

        //In Memory Object
        public int AddCompanionToEpisode(Companion companion,Episode episode)
        {
            episode.Companions.Add(companion);
            return context.SaveChanges();
        }

        public int UnAssignComapnionToEpiasode(int episodeId, int companionId)
        {
            var oldCompanionEpisode = context.CompanionEpisode
                .FirstOrDefault(ec => ec.CompanionId == companionId && ec.EpisodeId == episodeId);
            if (oldCompanionEpisode != null)
            {
                context.CompanionEpisode.Remove(oldCompanionEpisode);
                var oldEpisode = context.Episodes.Find(episodeId);
                var companion = context.Companions.Find(companionId);
                oldEpisode.Companions.Remove(companion);
            }
            return context.SaveChanges();
        }

        public int ReAssignComapnionEpisode(int oldEpisodeId, int companionId,int newEpisodeId)
        {
            Episode oldEpisode, newEpisode;
            Companion companion;
            var oldComapnionEpisode = context.CompanionEpisode
             .FirstOrDefault(
             e => e.EpisodeId == oldEpisodeId && e.CompanionId==companionId
             );
            if (oldComapnionEpisode != null)
            {
                oldEpisode = context.Episodes.Find(oldEpisodeId);
                companion = context.Companions.Find(companionId);

                context.CompanionEpisode.Remove(oldComapnionEpisode);
                oldEpisode.Companions.Remove(companion);

                newEpisode = context.Episodes.Find(newEpisodeId);
                if (newEpisode != null)
                    newEpisode.Companions.Add(companion);

                context.CompanionEpisode.Add(new CompanionEpisode { CompanionId = companionId, EpisodeId = newEpisodeId });
            }

            return context.SaveChanges();
        }
    
    }
}
