using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Department : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _departId;

        public int DepartId 
        {
            get
            {
                return _departId;
            }
            set
            {
                _departId = value;
            }
        }
        private string _departName;

        

        public string DepartName 
        {
            get
            {
                return _departName;
            }
            set
            {
                _departName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DepartName"));
            }
        }
        public Department(int id, string name)
        {
            this.DepartId = id;
            this.DepartName = name;
        }
    }
}
