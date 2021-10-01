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
using language_learning_tracker.Languages_List;
using language_learning_tracker.Language_Data;
using Newtonsoft.Json;

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
        private List<string> Language_Name_List = new List<string>();
        public DiaryWindow()
        {
            InitializeComponent();
            Activity_Date.SelectedDate = DateTime.Today;
            Activity_Type.ItemsSource = Activities_List;
            Status_Type.ItemsSource = Status_List;
            Language_List = Initialize_LanguageList();
            
            foreach (LanguageList lang in Language_List)
            {
                Language_Name_List.Add(lang.LanguageName);
            }
            Language_Name.ItemsSource = Language_Name_List;
        }

        private List<LanguageList> Initialize_LanguageList()
        {
            string languageListPath = @".\Language_List\LanguageList.json";
            using (StreamReader sr = new StreamReader(languageListPath))
            {
                string languageListJSON = sr.ReadToEnd();
                List<LanguageList> languageLists = JsonConvert.DeserializeObject<List<LanguageList>>(languageListJSON);
                return languageLists;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Close the diary window
            this.Close();
        }
    }
}

