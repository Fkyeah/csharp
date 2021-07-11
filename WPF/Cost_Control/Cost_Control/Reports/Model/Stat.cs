using Cost_Control.CostManager.Model;

namespace Cost_Control.Reports.Model
{
    public class Stat
    {
        public User User { get; set; }
        public string CostName { get; set; }
        public double Sum { get; set; }

        public Stat(User user, string costName, double sum)
        {
            User = user;
            CostName = costName;
            Sum = sum;
        }
    }
}
