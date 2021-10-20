using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using language_learning_tracker.Language_Data;

namespace language_learning_tracker
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private string Total_Hours_Box_String = "None";
        private List<LanguageList> Language_List;
        private LanguageDataDbContext LanguageDataContext;
        public ReportWindow()
        {
            InitializeComponent();
            LanguageDataContext = new LanguageDataDbContext();
            Start_Date.SelectedDate = DateTime.Today;
            End_Date.SelectedDate = DateTime.Today;
            Language_List = LanguageDataContext.Language.ToList();
            Language_Name.ItemsSource = Language_List.Select(s => s.LanguageName);
            SetTotalHoursBox();
        }

        private void SetTotalHoursBox()
        {
            Binding Total_Hours_Box_Binding = new Binding();
            Total_Hours_Box_Binding.Source = Total_Hours_Box_String;
            Total_Hours_Box.SetBinding(TextBlock.TextProperty, Total_Hours_Box_Binding);
        }

        private void ViewReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (Language_Name.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a language!");
                return;
            }

            string selectedLanguage = Language_Name.SelectedItem.ToString();
            DateTime startDate = Start_Date.SelectedDate.GetValueOrDefault();
            DateTime endDate = End_Date.SelectedDate.GetValueOrDefault();

            var report =
                from LanguageActivity in LanguageDataContext.LanguageActivities join LanguageList in LanguageDataContext.Language
                on LanguageActivity.LanguageID equals LanguageList.LanguageID join ImmersionMedia in LanguageDataContext.ImmersionMediaDB
                on LanguageActivity.MediaID equals ImmersionMedia.MediaID
                where LanguageList.LanguageName == selectedLanguage && LanguageActivity.ActivityDate >= startDate
                && LanguageActivity.ActivityDate <= endDate
                orderby LanguageActivity.ActivityDate, LanguageActivity.ActivityType
                select new { LanguageList.LanguageName, LanguageActivity.ActivityDate, ImmersionMedia.MediaName, ImmersionMedia.MediaType, LanguageActivity.ActivityType, LanguageActivity.TimeTaken };

            var ActivityList = report.ToList();
            Language_DataGrid.ItemsSource = ActivityList;
            List<TimeSpan> ActivityHours = report.Select(s => s.TimeTaken).ToList();

            if (ActivityHours.Count == 0)
            {
                Total_Hours_Box_String = "None";
                SetTotalHoursBox();
            }
            else
            {
                TimeSpan timeSum = TimeSpan.Zero;
                for (int i = 0; i < ActivityHours.Count; i++)
                    timeSum = timeSum.Add(ActivityHours[i]);
                Total_Hours_Box_String = timeSum.ToString();
                SetTotalHoursBox();
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Close the window
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            LanguageDataContext.Dispose();
            base.OnClosing(e);
        }
    }
}
