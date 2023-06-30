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
using System.Windows.Shapes;

namespace DoJudo.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddPartitcipantCompetitionWindow.xaml
    /// </summary>
    public partial class AddPartitcipantCompetitionWindow : Window
    {
        public AddPartitcipantCompetitionWindow(Participant participant)
        {
            InitializeComponent();
            DataContext = new AddParticipantCompetitionWindowViewModel(participant);
            (DataContext as AddParticipantCompetitionWindowViewModel).CloseWindowEvent += CloseWindowEventHandler;
        }

        private void CloseWindowEventHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
