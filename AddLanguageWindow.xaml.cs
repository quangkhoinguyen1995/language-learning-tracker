using System;
using System.IO;
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
using language_learning_tracker.Languages_List;
using Newtonsoft.Json;

namespace language_learning_tracker
{
    /// <summary>
    /// Interaction logic for AddLanguageWindow.xaml
    /// </summary>
    public partial class AddLanguageWindow : Window
    {
        public AddLanguageWindow()
        {
            InitializeComponent();
        }

        private void AddLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            string LanguageName = Language_Name.Text;
            string LanguageDataPath = @".\Language_Data\" + LanguageName + ".json";
            LanguageList newLanguage = new LanguageList(LanguageName, LanguageDataPath);
            string LanguageListPath = @".\Language_List\LanguageList.json";

            if(!File.Exists(LanguageListPath))
            {
                System.IO.Directory.CreateDirectory(@".\Language_List");
                System.IO.Directory.CreateDirectory(@".\Language_Data");
                List<LanguageList> languageLists = new List<LanguageList>();
                languageLists.Add(newLanguage);
                string JSONLanguage = JsonConvert.SerializeObject(languageLists);

                using (StreamWriter sw = File.CreateText(LanguageListPath))
                {
                    sw.WriteLine(JSONLanguage.ToString());
                    sw.Close();
                }

                File.CreateText(LanguageDataPath).Close();
            } 
            else if (File.Exists(LanguageListPath))
            {
                List<LanguageList> languageLists = new List<LanguageList>();
                using (StreamReader sr = new StreamReader(LanguageListPath))
                {
                    string languageListJSON = sr.ReadToEnd();
                    languageLists = JsonConvert.DeserializeObject<List<LanguageList>>(languageListJSON);
                    sr.Close();
                }
                foreach (LanguageList lang in languageLists)
                {
                    if (lang.LanguageName == newLanguage.LanguageName)
                    {
                        MessageBox.Show("Language is already added!");
                        return;
                    }
                }

                languageLists.Add(newLanguage);
                using (StreamWriter sw = File.CreateText(LanguageListPath))
                {
                    string JSONLanguage = JsonConvert.SerializeObject(languageLists);
                    sw.WriteLine(JSONLanguage.ToString());
                    sw.Close();
                }
                File.CreateText(LanguageDataPath).Close();
            }

            MessageBox.Show(LanguageName + " has been successfully added!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
