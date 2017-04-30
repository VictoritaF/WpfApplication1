using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication1.ViewModels;

namespace WpfApplication1.Models
{
    class SerializationActions
    {

        public void SerializeObject(string xmlFileName, UserViewModel entity)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(UserViewModel));
            FileStream fileStr = new FileStream(xmlFileName, FileMode.Create);
            xmlser.Serialize(fileStr, entity);
            fileStr.Dispose();
        }

        public UserViewModel DeserializeObject(string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(UserViewModel));
            FileStream file = new FileStream(xmlFileName, FileMode.Open);
            var entity = xmlser.Deserialize(file);
            file.Dispose();
            return entity as UserViewModel;
        }
    }
}
