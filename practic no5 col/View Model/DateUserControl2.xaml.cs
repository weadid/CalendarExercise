﻿using practic_no5_col.Models;
using practic_no5_col.Pages;
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

namespace practic_no5_col.View_Model
{
    /// <summary>
    /// Логика взаимодействия для DateUserControl2.xaml
    /// </summary>
    public partial class DateUserControl2 : UserControl
    {
        
            DateExercises dateExercises;
            DateTime date;
            public DateUserControl2(DateTime date, DateExercises dateExercises = null)
            {
                InitializeComponent();
                this.dateExercises = dateExercises;
                this.date = date;
                DayLabel.Content = date.Day;
                if (dateExercises != null)
                {
                    DayImage.Source = dateExercises.Exercises[0].ImageSource;
                }
            }

            private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {

                PageNavigation.MainFrame.Navigate(new DatePage(date, dateExercises));
            }
        
    }
}
