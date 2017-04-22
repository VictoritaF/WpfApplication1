using System;

using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using WpfApplication1.ViewModels;
using System.Diagnostics;

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
            DataContext = new UserViewModel();
        }

        UserViewModel userviewmodel = new UserViewModel();
        private int i = 0;
        private int j = 3;

        private void ShiftRightButton_Click(object sender, RoutedEventArgs e)
        {
            ImageSource imageSource = new BitmapImage(new Uri(userviewmodel.Images[i]));
            images.Source = imageSource;
            if (i < 3)
            {
                i++;
            }
            else if (i == 3)
            {
                i = 0;
            }
        


        }

        private void ShiftLeftButton_Click(object sender, RoutedEventArgs e)
        {

            ImageSource imageSource = new BitmapImage(new Uri(userviewmodel.Images[j]));
            images.Source = imageSource;
            if (j > 0)
            {
                j--;
            }
            else if (j == 0)
            {
                j = 3;
            }
        }

        private void images_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            string path = (images.Source as BitmapImage).UriSource.AbsolutePath;
            foreach (User user in userviewmodel.Users)
            {
                if (user.image.Equals(path))
                {
                    MessageBox.Show(user.name);
                }
            }
        }
    }
}
