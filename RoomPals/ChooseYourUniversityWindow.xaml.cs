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

namespace RoomPals
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseYourUniversityWindow.xaml
    /// </summary>
    public partial class ChooseYourUniversityWindow : Window
    {
        public ChooseYourUniversityWindow()
        {
            InitializeComponent();
            UserNameTextBlock.Text = "Example:)!";
        }

        private void ConfirmYourChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            ChooseFirstLanguage chooseFirstLanguage = new ChooseFirstLanguage();
            chooseFirstLanguage.Show();
            this.Hide();
        }
    }
}
