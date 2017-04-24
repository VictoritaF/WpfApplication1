using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Diagnostics;
using WpfApplication1.ViewModels.Commands;
using System.Runtime.CompilerServices;

namespace WpfApplication1.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public UserViewModel()
        {
            setUserList();
            SelectedItem = Users[0];
            setSelectedItemImage(SelectedItem.image);
            AddNewUserCommand = new AddNewUserCommand(this);
            NextUserCommand = new SelectNextUserCommand(this);
            PreviousUserCommand = new SelectPreviousUserCommand(this);
            DeleteUserCommand = new DeleteUserCommand(this);
            CancelWindowCommand = new CancelMainWindowCommand(this);

        }

        private ObservableCollection<User> users { get; set; }

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public void setUserList()
        {
            Users = new ObservableCollection<User>();
            Users.Add(new User() { name = "Ana", image = "D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Ana_Sun.jpg" });
            Users.Add(new User() { name = "Mircea", image = "D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Mircea_Bear.jpg" });
            Users.Add(new User() { name = "Andreea", image = "D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Andreea_Flower.jpg" });
            Users.Add(new User() { name = "Alexandru", image = "D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Alexandru_Rabbit.jpg" });
            Users.Add(new User() { name = "Alina", image = "D:/Facultate/an2/sem2/MVP/Tema2/UserImages/Andreea_Flower.jpg" });
        }

        private User selectedItem { get; set; }
        public User SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value == selectedItem)
                    return;

                selectedItem = value;
                setSelectedItemImage(SelectedItem.image);
                OnPropertyChanged("SelectedItem");
            }
        }

        private string selectedItemImage { get; set; }
        public string SelectedItemImage
        {
            get { return selectedItemImage; }
            set
            {
                if (value == selectedItemImage)
                    return;

                selectedItemImage = value;
                OnPropertyChanged("SelectedItemImage");

            }
        }

        private void setSelectedItemImage(string imagePath)
        {
            SelectedItemImage = imagePath;
        }

        public AddNewUserCommand AddNewUserCommand { get; set; }
        public SelectNextUserCommand NextUserCommand { get; set; }
        public SelectPreviousUserCommand PreviousUserCommand { get; set; }
        public DeleteUserCommand DeleteUserCommand { get; set; }
        public CancelMainWindowCommand CancelWindowCommand { get; set; }

        public string NewUserName { get; set; }

        public void AddNewUser()
        {
            Users.Add(new User() { name = NewUserName, image = SelectedItemImage });
        }

        public void SelectPreviousUser()
        {
            int currentPosition = Users.IndexOf(SelectedItem);
            if (currentPosition > 0)
            {
                currentPosition--;
            }
            else
            {
                currentPosition = Users.Count() - 1;
            }
            SelectedItem = Users[currentPosition];
        }

        public void SelectNextUser()
        {
            int currentPosition = Users.IndexOf(SelectedItem);
            if (currentPosition < Users.Count() - 1)
            {
                currentPosition++;
            }
            else
            {
                currentPosition = 0;
            }
            SelectedItem = Users[currentPosition];
        }

        public void DeleteUser()
        {
            User selectedUser = SelectedItem;
            SelectedItem = Users[Users.IndexOf(SelectedItem) - 1];
            Users.Remove(selectedUser);
           
            
        }

        public void CancelMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //public void setImageBox()
        //{
        //    Image images = new Image();
        //    ImageSource imageSource = new BitmapImage(new Uri(Images[0]));
        //    images.Source = imageSource;

        //}
    }
}
