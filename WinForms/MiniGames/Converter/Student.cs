using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;


namespace Converter
{
    [Serializable]
    public class Student
    {
        private string _firstName;
        private string _secondName;
        private string _univercity;
        private string _faculty;
        private int _age;
        private int _course;
        private string _group;
        private string _city;
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string SecondName { get { return _secondName; } set { _secondName = value; } }
        public string Univercity { get { return _univercity; } set { _univercity = value; } }
        public string Faculty { get { return _faculty; } set { _faculty = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public int Course { get { return _course; } set { _course = value; } }
        public string Group { get { return _group; } set { _group = value; } }
        public string City { get { return _city; } set { _city = value; } }
    }
}
