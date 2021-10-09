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
using Microsoft.EntityFrameworkCore.Sqlite;
using language_learning_tracker.Language_Data;
using System.ComponentModel;

namespace language_learning_tracker
{
    /// <summary>
    /// Interaction logic for AddLanguageWindow.xaml
    /// </summary>
    public partial class AddLanguageWindow : Window
    {
        LanguageDataDbContext LanguageDataContext;
        public AddLanguageWindow()
        {
            InitializeComponent();
            LanguageDataContext = new LanguageDataDbContext();
        }

        private void AddLanguageButton_Click(object sender, RoutedEventArgs e)
        {
            string LanguageName = Language_Name.Text;

            var langExist = LanguageDataContext.Language.Where(s => s.LanguageName == LanguageName).FirstOrDefault();

            if (langExist == null)
            {
                LanguageList lang = new LanguageList(LanguageName);
                LanguageDataContext.Add(lang);
                LanguageDataContext.SaveChanges();
                MessageBox.Show(LanguageName + " is sucessfully added!");
            }
            else
            {
                MessageBox.Show(LanguageName + " is already in database!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            LanguageDataContext.Dispose();
            base.OnClosing(e);
        }
    }
}
