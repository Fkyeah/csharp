using Cost_Control.CostManager.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Cost_Control.Reports.Model
{
    public static class Stats
    {
        public static ObservableCollection<Cost> GetStatInPeriod(string userName, string fromDate, string toDate)
        {
            DateTime fromDateTime = Convert.ToDateTime(fromDate);
            DateTime toDateTime = Convert.ToDateTime(toDate);
            var temp = CostList.Costs
                .Where(t => t.Date > fromDateTime && t.Date < toDateTime && t.User.Name == userName).ToList();
            return GroupCosts(temp);
        }
        private static ObservableCollection<Cost> GroupCosts(List<Cost> costs)
        {
            ObservableCollection<Cost> result = new ObservableCollection<Cost>();
            result.Add(costs.First());
            foreach (var el in costs)
            {
                if (!(result.Any(t => t.CostName == el.CostName)))
                    result.Add(el);
                else
                    result.First(t => t.CostName == el.CostName).Sum += el.Sum;
            }
            return result;
        }
    }
}
