

namespace AddressBook.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        
        public Contact(int id, string name, string lastName, string phoneNumber)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public Contact()
        {

        }
    }
}
