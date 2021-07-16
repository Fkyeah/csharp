using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AddressBook.Model
{
    [Serializable]
    public static class ContactList
    {
        public static ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        private static string _fileName = "ContactList.xml";
        private static XmlSerializer _formatter;
        public static ObservableCollection<Contact> Load()
        {
            _formatter = new XmlSerializer(typeof(ObservableCollection<Contact>));
            try
            {
                FileStream _fs = new FileStream(_fileName, FileMode.OpenOrCreate);
                Contacts = (ObservableCollection<Contact>)_formatter.Deserialize(_fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Contacts;
        }
        public static void Save(ObservableCollection<Contact> contacts)
        {
            FileStream _fs = new FileStream(_fileName, FileMode.Create);
            _formatter = new XmlSerializer(typeof(ObservableCollection<Contact>));
            _formatter.Serialize(_fs, contacts);
        }
    }
}
