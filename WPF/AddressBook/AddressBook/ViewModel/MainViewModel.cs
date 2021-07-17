using AddressBook.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    class MainViewModel : ObservableObject
    {   
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        private ObservableCollection<Contact> _contacts = ContactList.Load();
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                if (value != _contacts)
                {
                    _contacts = value;
                    OnPropertyChanged("Contacts");
                }
            }
        }
        public Contact SelectedContact { get; set; }
        #region Click Button Add Contact
        public ICommand ClickAdd
        {
            get => new DelegateCommand(AddContact, CanAdd);
        }
        private void AddContact(object obj)
        {
            Contacts.Add(new Contact(Contacts.Last().Id + 1, Name, LastName, PhoneNumber));
        }
        private bool CanAdd(object obj) 
            => Name != null && LastName != null && PhoneNumber != null && !(Contacts.Any(el => el.PhoneNumber == PhoneNumber));
        #endregion
        #region Click Button Delete Contact
        public ICommand ClickDelete
        {
            get => new DelegateCommand(DeleteContact, CanDelete);
        }
        private void DeleteContact(object obj)
        {
            Contacts.Remove(SelectedContact);
        }
        private bool CanDelete(object obj) => SelectedContact != null;
        #endregion
        #region Click Button Power
        public ICommand ClickPower
        {
            get => new DelegateCommand(OffProgram, CanAlways);
        }
        private void OffProgram(object obj)
        {
            ContactList.Save(Contacts);
            Environment.Exit(0);
        }
        private bool CanAlways(object obj) => true;
        #endregion
    }
}
