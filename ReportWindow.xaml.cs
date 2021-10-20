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
            Binding Total_Hours_Box_Binding = new Binding();
            Total_Hours_Box_Binding.Source = Total_Hours_Box_String;
            Total_Hours_Box.SetBinding(TextBlock.TextProperty, Total_Hours_Box_Binding);
        }

        private void ViewReportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Close the window
            this.Close();
        }
    }
}
