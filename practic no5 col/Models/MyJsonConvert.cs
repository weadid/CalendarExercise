using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic_no5_col.Models
{
    public static class MyJsonConvert
    {
        private const string PATH = "DateExercises.json";

        public static void ReadJson()
        {
            if (File.Exists(PATH))
            {
                DateExercises.DateExercisesList = JsonConvert.DeserializeObject<List<DateExercises>>(File.ReadAllText(PATH));
            }


        }

        public static void WriteJson()
        {
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();

            }

            File.WriteAllText(PATH, JsonConvert.SerializeObject(DateExercises.DateExercisesList));
        }
    }

}
