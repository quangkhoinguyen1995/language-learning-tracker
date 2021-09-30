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

            string JSONLanguage = JsonConvert.SerializeObject(newLanguage);

            if(!File.Exists(LanguageListPath))
            {
                System.IO.Directory.CreateDirectory(@".\Language_List");
                System.IO.Directory.CreateDirectory(@".\Language_Data");
                using (StreamWriter sw = File.CreateText(LanguageListPath))
                {
                    sw.WriteLine(JSONLanguage.ToString());
                    sw.Close();
                }

                File.CreateText(LanguageDataPath).Close();
            } 
            else if (File.Exists(LanguageListPath))
            {
                using (StreamWriter sw = File.AppendText(LanguageListPath))
                {
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
