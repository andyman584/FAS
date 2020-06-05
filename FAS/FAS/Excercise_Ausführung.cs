using SQLite;
using System;

namespace FAS
{
    public class Excercise_Ausführung
    {
        public Excercise_Ausführung()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int counter_id { get; set; }

        //Group the Excercises
        public int execution_id { get; set; }
        public int trainingsplan_id { get; set; }
        public int excercise_id { get; set; }
        public string excercise_name { get; set; }
        public int sets { get; set; }
        public int reps { get; set; }
        public int wheight { get; set; }
        public DateTime start { get; set; }
    }
}