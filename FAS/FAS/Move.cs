using SQLite;

namespace FAS
{
    public class Move
    {
        public Move()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int move_id { get; set; }
        public string name { get; set; }
    }
}