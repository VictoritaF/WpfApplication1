using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    class User: INotifyPropertyChanged
    {
        private string Name;
        private string Image;
        public User(String Username, String UserImage)
        {
            name = Username;
            image = UserImage;
        }

        public string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string image
        {
            get
            {
                return Image;
            }
            set
            {
                Image = value;
                OnPropertyChanged("Image");
            }
            
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
