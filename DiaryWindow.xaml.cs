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
            
            if (Language_Name.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a language!");
                return;
            }
            else
            {
                string selectedLanguage = Language_Name.SelectedItem.ToString();
                activity.LanguageID = LanguageDataContext.Language.Where(l => l.LanguageName == selectedLanguage).Select(p => p.LanguageID).Single();
            }

            if (Activity_Type.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an activity");
                return;
            }
            else
                activity.ActivityType = Activity_Type.SelectedItem.ToString();

            if (Media_Name.Text.Length == 0 || Media_Type.Text.Length == 0 || Time_taken.Text.Length == 0)
            {
                MessageBox.Show("Please fill out all the info!");
                return;
            }

            TimeSpan timeTaken = TimeSpan.FromHours(Double.Parse(Time_taken.Text));
            activity.TimeTaken = timeTaken;
            ImmersionMedia iMedia = CheckOrCreateMedia(Media_Name.Text, Media_Type.Text, activity.LanguageID, timeTaken);
            activity.MediaID = iMedia.MediaID;
            LanguageDataContext.Add(activity);
            LanguageDataContext.SaveChanges();
            MessageBox.Show("Activity sucessfully added!");
        }

        private ImmersionMedia CheckOrCreateMedia (string Media_Name, string Media_Type, int LanguageID, TimeSpan timeTaken)
        {
            int MediaIDQuery = LanguageDataContext.ImmersionMediaDB.Where(
                m => m.MediaName == Media_Name && m.MediaType == Media_Type && m.LanguageID == LanguageID).Select(
                m => m.MediaID).FirstOrDefault();

            if (MediaIDQuery != 0)
            {
                ImmersionMedia requestedMedia = LanguageDataContext.ImmersionMediaDB.Where(
                    m => m.MediaName == Media_Name && m.MediaType == Media_Type && m.LanguageID == LanguageID).FirstOrDefault();
                requestedMedia.TotalImmersionTimes += timeTaken;
                LanguageDataContext.Update(requestedMedia);
                return requestedMedia;
            }
            else
            {
                ImmersionMedia requestedMedia = new ImmersionMedia(Media_Name);
                requestedMedia.MediaType = Media_Type;
                requestedMedia.LanguageID = LanguageID;
                requestedMedia.TotalImmersionTimes = timeTaken;
                LanguageDataContext.Add(requestedMedia);
                return requestedMedia;
            }
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

