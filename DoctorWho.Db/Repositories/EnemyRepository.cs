using DoctorWho.Db.DataModels;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddEnemy(string enemyName,string description)
        {
            Enemy enemy = new Enemy()
            {
                EnemyName = enemyName,
                Description = description
            };
           context.Enemies.Add(enemy);
          return context.SaveChanges();
        }
        public int DeleteEnemy(int id)
        {
            var enemy = context.Enemies.Find(id);
            if (enemy != null)
                context.Enemies.Remove(enemy);
          return context.SaveChanges();
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
        public int UpdateEnemy(int id, string enemyName,string descripton)
        {
            var enemy=context.Enemies.Find(id);
            if (enemy != null) 
            {
                enemy.Description = descripton;
                enemy.EnemyName = enemyName;
            }
         return context.SaveChanges();
        }

    }
}
