using Cost_Control.CostManager.Model;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Cost_Control.Reports.Model
{
    public class StatsList
    {
        private CostList costLists = new CostList();

        public ObservableCollection<Cost> GetStatInPeriod(CostList costList, string userName, DateTime fromDate, DateTime toDate)
        {
            costList.LoadCosts();
            var temp = costList.Costs.Where(t => t.Date >= fromDate && t.Date <= toDate && t.User.Name == userName).ToList();
            return GroupCosts(temp);
        }
        private ObservableCollection<Cost> GroupCosts(List<Cost> costs)
        {
            ObservableCollection<Cost> result = new ObservableCollection<Cost>();
            try
            {
                result.Add(costs.First());
                foreach (var el in costs)
                {
                    if (!(result.Any(t => t.CostName == el.CostName)))
                        result.Add(el);
                    else
                        result.First(t => t.CostName == el.CostName).Sum += el.Sum;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
