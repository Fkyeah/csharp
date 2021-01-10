using System;


namespace Workers
{
     abstract class Base : IComparable<Base>
    {
        private int _salary;
        private string _name;
        public int Salary { get { return _salary; } protected set { _salary = value; } }
        public string Name { get { return _name; } protected set { _name = value; } }

        public Base(int salary, string name)
        {
            _salary = salary;
            _name = name;
        }
        public abstract double CalcAvgSalary();

        public int CompareTo(Base o)
        {
            if (this.CalcAvgSalary() > o.CalcAvgSalary()) return 1;
            if (this.CalcAvgSalary() == o.CalcAvgSalary()) return 0;
            return -1;
        }
        public override string ToString()
        {
           return $"{Name} - {Salary}. Average salary - {CalcAvgSalary()}"; 
        }
    }
    class Hourly : Base
    {
        public Hourly (int salary, string name) : base(salary, name)
        {
        }
        public override double CalcAvgSalary()
        {
            return Salary * 8 * 20.8;
        }
    }
    class Monthly : Base
    {
        public Monthly (int salary, string name) : base(salary, name)
        {
        }
        public override double CalcAvgSalary()
        {
            return Salary;
        }
    }
}
