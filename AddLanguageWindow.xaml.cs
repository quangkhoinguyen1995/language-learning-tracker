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
using language_learning_tracker.Language_Data;

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
            
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
