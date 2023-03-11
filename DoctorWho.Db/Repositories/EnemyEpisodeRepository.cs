using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EnemyEpisodeRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddEnemyToEpisode(int enemyId, int episodeId)
        {
            var episode = context.Episodes.Find(episodeId);
            var enemy = context.Enemies.Find(enemyId);

            if (episode != null && enemy != null)
                episode.Enemies.Add(enemy);
            return context.SaveChanges();
        }

        //In Memory Object
        public int AddEnemyToEpisode(Enemy enemy, Episode episode)
        {
            episode.Enemies.Add(enemy);
            return context.SaveChanges();
        }

        public int UnAssignEnemyToEpiasode(int episodeId, int enemyId)
        {
            var result = context.EnemyEpisode.FirstOrDefault
                (
                e => e.EpisodeId == episodeId && e.EnemyId == enemyId
                );
            if (result != null)
                context.Remove(result);

            return context.SaveChanges();
        }

        public int ReAssignEnemyEpisode(int oldEpisodeId,int enemyId, int newEpisodeId)
        {
            Episode oldEpisode,newEpisode;
            Enemy enemy;
               var oldEnemyEpisode = context.EnemyEpisode
                .FirstOrDefault(
                e => e.EpisodeId == oldEpisodeId && e.EnemyId == enemyId
                );
            if (oldEnemyEpisode != null)
            {
                oldEpisode = context.Episodes.Find(oldEpisodeId);
                enemy = context.Enemies.Find(enemyId);

                context.EnemyEpisode.Remove(oldEnemyEpisode);
                oldEpisode.Enemies.Remove(enemy);
                
                newEpisode = context.Episodes.Find(newEpisodeId);
                if (newEpisode != null)
                    newEpisode.Enemies.Add(enemy);

                context.EnemyEpisode.Add(new EnemyEpisode { Episode = newEpisode, Enemy = enemy });

            }

            return context.SaveChanges();
        }


    }
}
