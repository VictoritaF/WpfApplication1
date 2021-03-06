﻿using System;
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
using System.Xml.Serialization;

namespace WpfApplication1.ViewModels
{
    [Serializable]
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
            OpenWindowOnPlayCommand = new PlayCommand(this);
            SelectCategoryCommand = new SelectCategoryCommand(this);
           // SetCategoryNameCommand = new SetCategoryNameCommand(this);
        }
        [XmlArray]
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
        [XmlAttribute]
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
        [XmlAttribute]
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
        public PlayCommand OpenWindowOnPlayCommand { get; set; }
        public SelectCategoryCommand SelectCategoryCommand { get; set; }
       // public SetCategoryNameCommand SetCategoryNameCommand { get; set; }

        [XmlAttribute]
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

        public void OpenWindowOnPlay()
        {
        }

        //}
        //[XmlArray]
        //public string[] RiversList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/Rivers.txt");
        //[XmlArray]
        //public string[] SeasList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/Seas.txt");
        //[XmlArray]
        //public string[] StatesList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/States.txt");
        //[XmlArray]
        //public string[] AllList = System.IO.File.ReadAllLines(@"D:/Facultate/Visual Studio Projects/an2sem2c#/HangmanWordsCategories/All Categories.txt");
        //[XmlAttribute]
        //private string riversName { get; set; }
        //public string RiversName
        //{
        //    get { return riversName; }
        //    set
        //    {
        //        riversName = value;
        //        OnPropertyChanged("RiversName");
        //    }
        //}
        //[XmlAttribute]
        //private string seasName { get; set; }
        //public string SeasName
        //{
        //    get { return seasName; }
        //    set
        //    {
        //        seasName = value;
        //        OnPropertyChanged("SeasName");
        //    }
        //}
        //[XmlAttribute]
        //private string statesName { get; set; }
        //public string StatesName
        //{
        //    get { return statesName; }
        //    set
        //    {
        //        statesName = value;
        //        OnPropertyChanged("StatesName");
        //    }
        //}
        //[XmlAttribute]
        //private string allName { get; set; }
        //public string AllName
        //{
        //    get { return allName; }
        //    set
        //    {
        //        allName = value;
        //        OnPropertyChanged("AllName");
        //    }
        //}

        public void SetCategoryName(object paramter)
        {
        //    RiversName = "Rivers";
        //    SeasName = "Seas";
        //    StatesName = "States";
        //    AllName = "All Categories";

        }

        //private List<List<string>> categories { get; set; }

        //public List<List<string>> Categories
        //{
        //    get { return categories; }
        //    set { categories = value; }
        //}

        //public void setCategoriesList()
        //{

        //}
        //[XmlAttribute]
        //private string selectedItemInCategory { get; set; }
        //public string SelectedItemInCategory
        //{
        //    get { return selectedItemInCategory; }
        //    set
        //    {
        //        selectedItemInCategory = value;
        //        OnPropertyChanged("SelectedItemInCategory");
        //    }

        //}

        //public void SelectACategory()
        //{
        //    MakeLabels();
        //    // SelectedItemInCategory = RiversList[2];

        //    //foreach (char character in RiversList[2])
        //    //{
        //    //  SelectedItemInCategory[0] = "_";
        //    //}
        //}


        //public string GetRandomWord()
        //{
        //    Random random = new Random();
        //    string word = RiversList[random.Next(0, RiversList.Length - 1)];
        //    return word;
        //}
        //[XmlAttribute]
        //string word = "";
        ////List<Label> labels = new List<Label>();

        //public void MakeLabels()
        //{
        //    word = GetRandomWord();
        //    char[] chars = word.ToCharArray();
        //    string underscores = "";
        //    int between = 142 / chars.Length - 1;
        //    for (int i = 0; i < chars.Length; i++)
        //    {
        //        underscores = underscores + "_  ";
                //labels.Add(new Label());
                //labels[i].Content = "_";
                //int n = (i * between) + 10;
                //labels[i].Height = 18;
                //labels[i].Width = 21;
                //labels[i].Margin = new Thickness(n, 220, 0, 0);
                //View.NewGameWindow ngw = new View.NewGameWindow();
                //ngw.Grid.Children.Add(labels[i]);
                //labels[i].Parent = ngw.LabelsTextBox;
        //    }
        //    SelectedItemInCategory = underscores;

        //}



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
