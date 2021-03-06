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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore.Sqlite;
using language_learning_tracker.Language_Data;
using System.ComponentModel;

namespace language_learning_tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDb();
        }
        private void InitializeDb()
        {
            string path = @".\Language_Data";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            LanguageDataDbContext LanguageDataContext = new LanguageDataDbContext();
            LanguageDataContext.Database.EnsureCreated();
            LanguageDataContext.Dispose();
        }

        private void DiaryButton_Click (object sender, RoutedEventArgs e)
        {
            LanguageDataDbContext LanguageDataContext = new LanguageDataDbContext();
            int langCount = LanguageDataContext.Language.Count();
            LanguageDataContext.Dispose();

            if (langCount == 0)
                MessageBox.Show("Language data is empty! Add language before proceeding!");
            else
            {
                DiaryWindow diaryWindow = new DiaryWindow();

                //Open the window
                diaryWindow.Show();
            }
        }

        private void ReportButton_Click (object sender, RoutedEventArgs e)
        {
            LanguageDataDbContext LanguageDataContext = new LanguageDataDbContext();
            int langCount = LanguageDataContext.Language.Count();
            LanguageDataContext.Dispose();

            if (langCount == 0)
                MessageBox.Show("Language data is empty! Add language before proceeding!");
            else
            {
                ReportWindow reportWindow = new ReportWindow(); ;

                //Open the window
                reportWindow.Show();
            }
        }

        private void AddLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            AddLanguageWindow addLanguageWindow = new AddLanguageWindow();

            //Open the window
            addLanguageWindow.Show();
        }
    }
}
