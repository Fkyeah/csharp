using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    public class Department
    {
        public int DepartId { get; set; }
        public string DepartName { get; set; }

        public Department(int id, string name)
        {
            this.DepartId = id;
            this.DepartName = name;
        }
    }
}
