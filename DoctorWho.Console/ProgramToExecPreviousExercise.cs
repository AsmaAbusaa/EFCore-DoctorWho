using DoctorWho.Db;
using DoctorWho.Db.DataModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
//printView();
void printView()
{
    var command = "SELECT * FROM viewReport";
    var result = context.viewReport.FromSqlRaw(command).ToList();
    foreach (var e in result)
        Console.WriteLine(e.ToString());
}

//GetEnemiesNameByID(301);
void GetEnemiesNameByID(int id)
{
    var result = context.Episodes
                  .Where(e => e.EpisodeId == id)
                  .Select
                  (a => context.GetEnemiesByEpisodeId(id)
                  ).ToList();
}

GetCompanionsNameByID(301);
void GetCompanionsNameByID(int id)
{
    var result = context.Episodes
                .Where(e => e.EpisodeId == id)
                .Select
                (a => context.GetCompanionsByEpisodeId(id)
                ).ToList();
    foreach (var x in result) Console.WriteLine(x);

}

//ExecuteSProcedure();
void ExecuteSProcedure()
{
    List<Enemy> enemies = new List<Enemy>();
    List<Companion> companions = new List<Companion>();
    var cmdText = "spSummariseEpisodes";
    var conn = new SqlConnection(context.Database.GetConnectionString());
    var cmd = new SqlCommand(cmdText, conn);
    conn.Open();
    var reder = cmd.ExecuteReader();
    while (reder.Read())
    {
        enemies.Add(new Enemy
        {
            EnemyId = reder.GetInt32("EnemyId"),
            EnemyName = reder.GetString("EnemyName"),
            Description = reder.GetString("Description"),
        });
    }
    reder.NextResult();
    while (reder.Read())
    {
        companions.Add(new Companion
        {
            CompanionId = reder.GetInt32("CompanionId"),
            CompanionName = reder.GetString("CompanionName"),
            WhoPlayed = reder.GetString("WhoPlayed"),
        });
    }
    conn.Close();
}

