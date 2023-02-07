using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddEnemy()
        {
            Enemy enemy = new Enemy()
            {
                EnemyName = "XEnemy",
                Description = "XEnemy is an Enemy"
            };
            var result = context.Enemies.Add(enemy);
            context.SaveChanges();
        }
        public void DeleteEnemy(int id)
        {
            var enemy = context.Enemies.Find(id);
            if (enemy != null)
                context.Enemies.Remove(enemy);
            context.SaveChanges();
        }
        public Enemy GetEnemyById(int id)
        {
            var enemy = context.Enemies.Find(id);
            if (enemy != null)
            {
                Console.WriteLine(enemy.EnemyName);
                return enemy;
            }
            throw new Exception("Not Found");
        }

    }
}
