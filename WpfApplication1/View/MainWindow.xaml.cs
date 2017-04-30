using System;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using WpfApplication1.ViewModels;
using System.Diagnostics;
using WpfApplication1.View;
using WpfApplication1.Models;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new UserViewModel();
        }

        private void button_Play_Click(object sender, RoutedEventArgs e)
        {
            PlayWindow playWindow = new PlayWindow();
            playWindow.Show();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            SerializationActions actions = new SerializationActions();
            actions.SerializeObject("test.xml", DataContext as UserViewModel);
            MessageBox.Show("Serializare efectuata cu succes!");
        }
    }
}
