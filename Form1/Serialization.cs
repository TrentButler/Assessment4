using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace Assessment4
{
    class DataSerialization
    {        
        public static void SerializeGame(string fName)
        {
            XmlSerializer gameSerializer = new XmlSerializer(typeof(Combat));

            TextWriter text = new StreamWriter(fName + "_" + System.DateTime.Now.ToLongDateString() + ".sav");
            
            gameSerializer.Serialize(text, Singleton.Instance.SaveCombat);

            text.Close();
        }
        public static Combat DeserializeGame(string fName)
        {
            Combat tmpCombat = null;

            XmlSerializer gameSerializer = new XmlSerializer(typeof(Combat)); 

            TextReader read = new StreamReader(fName);
            tmpCombat = (Combat)gameSerializer.Deserialize(read);
            read.Close();

            return tmpCombat;
        }
    }

    public class Singleton
    {
        private static Singleton instance;
        public Combat SaveCombat;
        public Random RNG;
        public static Singleton Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }        
        private Singleton() { }
    }
}
