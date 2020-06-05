using SQLite;

namespace FAS
{
    internal class Strength_Statistic_Sum
    {
        public Strength_Statistic_Sum()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int o_id { get; set; }
        public int exc_id { get; set; }
        public string name { get; set; }
        public int sum_sets { get; set; }
        public int sum_reps { get; set; }
        public int sum_wheight { get; set; }
        public int sum_all { get; set; }
    }
}