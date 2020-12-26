using System;


namespace Workers
{
     //1. Построить три класса(базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой(один из потомков) 
     //   и фиксированной оплатой(второй потомок).
    abstract class Base : IComparable
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
        // 1.а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы.
        public abstract double CalcAvgSalary();

        // 1.в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
        public int CompareTo(object o)
        {
            if (this.CalcAvgSalary() > ((o as Base).CalcAvgSalary())) return 1;
            if (this.CalcAvgSalary() == ((o as Base).CalcAvgSalary())) return 0;
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
