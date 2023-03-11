namespace DoctorWho.Db.DataModels
{
    public class Enemy
    {
        public Enemy()
        {
            Episodes = new List<Episode>();
        }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}
