using SQLite;
namespace FAS
{
    [Table("Trainingsplan_Basic")]
    public class Trainingsplan_Basic
    {

        [PrimaryKey, AutoIncrement]
        public int tp_id { get; set; }
        public string name { get; set; }

      
    }
}