using System;
using DataProvider;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XMLSerialization
{
    public class XMLProvider<T> : IDataProvider<T>
    {
        readonly string con;
        public XMLProvider(string path)
        {
            con = path;
        }
         
        public T Read()
        {
            T data;
            using (FileStream fs = new FileStream(con, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                try
                {
                    data = (T)formatter.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return data;
        }

        public void Write(List<T> data)
        {
            using (FileStream fs = new FileStream(con, FileMode.OpenOrCreate))
            {
                XmlSerializer formatter = new XmlSerializer(data.GetType());
                try
                {
                    formatter.Serialize(fs, data);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
