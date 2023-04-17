using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace practic_no5_col
{

    public class Exercise
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool Selected { get; set; }

        public Exercise(string name, string image, bool selected)
        {
            Name = name;
            ImagePath = image;
            Selected = selected;
        }
        public BitmapImage ImageSource
        {
            get
            {
                Uri uri = new Uri($"{Environment.CurrentDirectory}\\exercises\\{ImagePath}");
                return new BitmapImage(uri);
            }
        }

        public static List<Exercise> GetUnSelectedExercises()
        {
            List<Exercise> exercises = new List<Exercise>();
            exercises.Add(new Exercise("Ходьба на пятках", "WalkingOnHeels.png", false));
            exercises.Add(new Exercise("Ходьба на носках", "ErskWalking.png", false));
            exercises.Add(new Exercise("Ходьба", "Walking.png", false));
            exercises.Add(new Exercise("Прыжки", "Jump.png", false));
            exercises.Add(new Exercise("Наклоны", "LeaningToSide.png", false));
            exercises.Add(new Exercise("Бег", "Run.png", false));
            exercises.Add(new Exercise("Мельница", "Mill.png", false));
            exercises.Add(new Exercise("Приседания", "SitUps.png", false));
            return exercises;
        }

    }
}
