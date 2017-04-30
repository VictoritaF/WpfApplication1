using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace WpfApplication1
{
    [Serializable]
    public class User: INotifyPropertyChanged
    {
        
       
        public User()
        {
            
        }

        [XmlAttribute]
        private string Name;
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

        [XmlAttribute]
        private string Image;
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
