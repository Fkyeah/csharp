using System;

namespace Cost_Control.CostManager.Model
{
    public class Cost
    {
        public User User { get; set; }
        public string CostName { get; set; }
        public double Sum { get; set; }
        public DateTime Date { get; set; }

        public Cost(User user, string costName, double sum, DateTime date)
        {
            User = user;
            CostName = costName;
            Sum = sum;
            Date = date;
        }
    }
}
