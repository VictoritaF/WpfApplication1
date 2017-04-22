using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace WpfApplication1.ViewModels
{
    internal class UserViewModel
    {

        public ObservableCollection<string> Images { get; set; }

        public ObservableCollection<User> Users { get; set; }



        public UserViewModel()
        {
            setImageList();
            setUserList();
            setImageBox();
        }


        public void setUserList()
        {
            Users = new ObservableCollection<User>();
            Users.Add(new User("Ana", Images[0]));
            Users.Add(new User("Mircea", Images[1]));
            Users.Add(new User("Andreea", Images[2]));
            Users.Add(new User("Alexandru", Images[3]));

        }

        public void setImageList()
        {
            Images = new ObservableCollection<string>();
            Images.Add("D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Ana_Sun.jpg");
            Images.Add("D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Mircea_Bear.jpg");
            Images.Add("D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Andreea_Flower.jpg");
            Images.Add("D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Alexandru_Rabbit.jpg");

        }

        public string DisplayedImage => Images[0];
        public void setImageBox()
        {
            Image images = new Image();
            ImageSource imageSource = new BitmapImage(new Uri(Images[0]));
            images.Source = imageSource;


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
