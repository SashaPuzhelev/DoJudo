﻿using DoJudo.Models.Database;
using DoJudo.ViewModels;
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

namespace DoJudo.Views.Pages
{
    /// <summary>
    /// Interaction logic for CompetitionPage.xaml
    /// </summary>
    public partial class CompetitionPage : Page
    {
        public CompetitionPage(Competition competition)
        {
            InitializeComponent();
            DataContext = new CompetitionViewModel(competition);
        }
    }
}