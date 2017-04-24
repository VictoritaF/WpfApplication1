using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    public class User: INotifyPropertyChanged
    {
        private string Name;
        private string Image;
        public User()
        {
            
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
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
