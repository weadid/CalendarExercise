using practic_no5_col.Models;
using practic_no5_col.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practic_no5_col.Pages
{
    /// <summary>
    /// Логика взаимодействия для DatePage.xaml
    /// </summary>
    public partial class DatePage : Page
    {
        DateTime date; DateExercises dateExercises;
        string[] months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
        public DatePage(DateTime date, DateExercises dateExercises = null)
        {
            InitializeComponent();
            this.date = date;
            this.dateExercises = dateExercises;
            DateLabel.Content = $"{date.Day} {months[date.Month - 1]} {date.Year}";
            UpdateExerciseStackPanel();
        }

        private void UpdateExerciseStackPanel()
        {
            ExerciseStackPanel.Children.Clear();
            List<Exercise> exerciseList = Exercise.GetUnSelectedExercises();
            for(int i = 0; i < exerciseList.Count; i++)
            {
                if (dateExercises != null && dateExercises.Exercises.Where(e=>e.Name == exerciseList[i].Name).Count() > 0)
                {
                    exerciseList[i].Selected = true;   
                }

                ExerciseStackPanel.Children.Add(new ExerciseUserControl(exerciseList[i]));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PageNavigation.MainFrame.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(dateExercises == null)
            {
                dateExercises = new DateExercises(date, new List<Exercise>());
            }
            dateExercises.Exercises.Clear();

            List<ExerciseUserControl> exerciseUserControls = ExerciseStackPanel.Children.Cast<ExerciseUserControl>().ToList();

            for(int i = 0; i < exerciseUserControls.Count; i++)
            {
                Exercise exercise = exerciseUserControls[i].DataContext as Exercise;

                if (exercise.Selected)
                {
                    dateExercises.Exercises.Add(exercise);
                }

            }

            if(dateExercises.Exercises.Count > 0)
            {
                bool exist = false;
                for (int i = 0; i < DateExercises.DateExercisesList.Count; i++)
                {
                    if (DateExercises.DateExercisesList[i].Date == dateExercises.Date)
                    {
                        DateExercises.DateExercisesList[i] = dateExercises;
                        exist = true;
                        break;
                    }

                }

                if(!exist)
                {
                    DateExercises.DateExercisesList.Add(dateExercises);
                    
                }
                MyJsonConvert.WriteJson();

                PageNavigation.MainFrame.GoBack();
            }
            else
            {
                MessageBox.Show("Не выбраны упражнения для сохранения", "Ошибка");
            }
        }
    }
}
