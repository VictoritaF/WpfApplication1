using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;

namespace WpfApplication1.ViewModels
{
   internal class UserViewModel
    {
        public UserViewModel()
        {
             user = new User("David", "");
           
        }
        private User user;
        public User User
        {
            get
            {

                return user;
            }          
        }

        public void setUserList()
        {
            List<User> users = new List<User>();
            users.Add(new User("David", ""));
            users.Add(new User("Maria", ""));
        }
        private void ShiftRightButton_Click(object sender, RoutedEventArgs e)
        {
            setUserList();
        }
        //public string[] ReadFromFile()
        //{
        //    string[] lines = System.IO.File.ReadAllLines(@"D:\Facultate\an2\sem2\MVP\Tema2\Users.txt");
        //    foreach (string line in lines)
        //    {
        //        string[] token = line.Split(';');
        //        userListBox.Items.Add(token[0]);

        //        ImageSource imageSource = new BitmapImage(new Uri(token[1]));
        //        images.Source = imageSource;
        //    }
        //    return lines;
        //}

    }
}
