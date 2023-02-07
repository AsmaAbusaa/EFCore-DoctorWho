using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EnemyEpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddExistEnemyToEpisode()
        {
            var episode = context.Episodes.FirstOrDefault(x => x.EpisodeId == 1300);
            var enemy = context.Enemies.FirstOrDefault(c => c.EnemyId == 106);
            if (episode != null && enemy != null)
                episode.Enemies.Add(enemy);

            return context.SaveChanges();
        }

        public int ReAssignEnemyEpsiode()
        {
            var oldEpisode = context.Episodes
                                    .Include(s => s.Enemies.Where(s => s.EnemyId == 106))
                                    .FirstOrDefault(e => e.EpisodeId == 1300);
            var newEpisode = context.Episodes.Find(302);
            if (oldEpisode != null && newEpisode != null)
            {
                var enemy = oldEpisode.Enemies.ElementAt(0);
                oldEpisode.Enemies.Remove(enemy);
                newEpisode.Enemies.Add(enemy);
            }
            return context.SaveChanges();
        }

    }
}
