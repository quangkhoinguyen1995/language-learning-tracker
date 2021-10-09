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
        private LanguageDataDbContext LanguageDataContext;
        public MainWindow()
        {
            InitializeComponent();
            LanguageDataContext = InitializeDb();
        }

        private LanguageDataDbContext InitializeDb()
        {
            string path = @"./Language_Data/Language_Data.db";
            LanguageDataDbContext context = new LanguageDataDbContext(path);
            context.Database.EnsureCreated();
            return context;
        }

        private void DiaryButton_Click (object sender, RoutedEventArgs e)
        {
            DiaryWindow diaryWindow = new DiaryWindow();

            //Open the window
            diaryWindow.Show();
        }

        private void ReportButton_Click (object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new ReportWindow();

            //Open the window
            reportWindow.Show();
        }

        private void AddLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            AddLanguageWindow addLanguageWindow = new AddLanguageWindow();

            //Open the window
            addLanguageWindow.Show();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            LanguageDataContext.Dispose();
            base.OnClosing(e);
        }
    }
}
