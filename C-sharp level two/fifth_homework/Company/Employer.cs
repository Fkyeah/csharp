using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Department department { get; set; }

        public Employer(int id, string name, string lastName, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.department = department;
        }
        public Employer()
        {

        }
    }
}
