using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace practic_no5_col
{
    public class DateExercises
    {
        
        public DateTime Date { get; set; }
        public List<Exercise> Exercises = new List<Exercise>();
        public static List<DateExercises> DateExercisesList = new List<DateExercises>();

        public DateExercises(DateTime date, List<Exercise> exercises)
        {
            Date = date;
            Exercises = exercises;
        }

    }
}
