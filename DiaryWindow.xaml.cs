﻿using System;
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
using System.Windows.Shapes;
using System.IO;
using Microsoft.EntityFrameworkCore.Sqlite;
using language_learning_tracker.Language_Data;
using System.ComponentModel;

namespace language_learning_tracker
{
    /// <summary>
    /// Interaction logic for DiaryWindow.xaml
    /// </summary>
    public partial class DiaryWindow : Window
    {
        private List<string> Activities_List = new List<string>() { "Study", "Read", "Watch", "Play" };
        private List<string> Status_List = new List<string>() { "Started", "In progress", "Stalled", "Finished" };
        private List<LanguageList> Language_List;
        private LanguageDataDbContext LanguageDataContext;
        public DiaryWindow()
        {
            InitializeComponent();
            LanguageDataContext = new LanguageDataDbContext();
            Activity_Date.SelectedDate = DateTime.Today;
            Activity_Type.ItemsSource = Activities_List;
            Status_Type.ItemsSource = Status_List;
            Language_List = LanguageDataContext.Language.ToList();
            Language_Name.ItemsSource = Language_List.Select(s => s.LanguageName);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            LanguageActivity activity = new LanguageActivity();
            activity.ActivityDate = Activity_Date.SelectedDate.GetValueOrDefault();
            activity.ActivityType = Activity_Type.SelectedItem.ToString();
            if (Language_Name.SelectedIndex == -1)
                MessageBox.Show("Please select a language!");
            else
                activity.LanguageID = Language_Name.SelectedIndex;

            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Close the diary window
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            LanguageDataContext.Dispose();
            base.OnClosing(e);
        }
    }
}

