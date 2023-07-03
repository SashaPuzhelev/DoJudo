using DoJudo.ViewModels;
using System;
using System.Windows;

namespace DoJudo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (DataContext as MainWindowViewModel).CloseWindowEvent += CloseWindowEventHandler;
        }

        private void CloseWindowEventHandler(object sender, EventArgs e)
        {
            Close();
        }
    }
}
