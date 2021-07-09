using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LastName"));
            }
        }
        private int __department_Id;
        public int Department_Id
        {
            get
            {
                return __department_Id;
            }
            set
            {
                __department_Id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Department_Id"));
            }
        }
        
        public Employer(int id, string name, string lastName, int department_Id)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Department_Id = department_Id;
        }
        public Employer()
        {

        }
    }
}
