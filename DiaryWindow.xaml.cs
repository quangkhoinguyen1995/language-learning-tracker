﻿using System;
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

namespace Time_tracker
{
    /// <summary>
    /// Interaction logic for DiaryWindow.xaml
    /// </summary>
    public partial class DiaryWindow : Window
    {
        public DiaryWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Close the diary window
            this.Close();
        }
    }
}
