using SQLite;
namespace FAS
{
    public class Trainingsplan
    {
        public Trainingsplan()
        {
        }


        [PrimaryKey, AutoIncrement]
        public int counter_id { get; set; }
        public int tp_id { get; set; }
        public int exce_id { get; set; }
        public string name { get; set; }




    }
}