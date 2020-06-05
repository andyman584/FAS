using SQLite;

namespace FAS
{
    internal class Strength_Statistic_Change
    {
        public Strength_Statistic_Change()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int o_id { get; set; }
        public int exc_id { get; set; }
        public string name { get; set; }
        public string sets { get; set; }
        public string reps { get; set; }
        public string wheight { get; set; }
    }
}