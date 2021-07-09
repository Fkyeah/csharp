using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Converter
{
    class Converter
    {
        public List<Student> list;
        string fileName;
        public Converter(string _fileName)
        {
            this.fileName = _fileName;
            list = new List<Student>();
        }
        public void Load()
        {
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            while(!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(';');
                list.Add(new Student { FirstName = s[0], SecondName = s[1], Univercity = s[2], Faculty = s[3], Age = int.Parse(s[4]), Course = int.Parse(s[5]), Group = s[6], City = s[7] });
            }
            sr.Close();
        }
        public string getStudent(int _index)
        {
            return $"{list[_index].FirstName} {list[_index].SecondName} {list[_index].Univercity} {list[_index].Faculty} {list[_index].Age} {list[_index].Course} {list[_index].Group} {list[_index].City}";
        }
        public void Convert(string _fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }
    }
}
