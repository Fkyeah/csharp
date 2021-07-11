using System.Text.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Cost_Control.CostManager.Model
{
    [Serializable]
    public class CostList
    {
        private string _fileName = "JsonCosts.json";
        private ObservableCollection<Cost> _costs = new ObservableCollection<Cost>();
        public ObservableCollection<Cost> Costs
        {
            get => _costs;
        }
        public ObservableCollection<Cost> LoadCosts()
        {
            try
            {
                if (!File.Exists(_fileName))
                    File.Create(_fileName);
                string json = File.ReadAllText(_fileName);
                Console.WriteLine(json);
                _costs = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Cost>>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Costs;
        }

        public void SaveCosts()
        {
            string json = JsonSerializer.Serialize(Costs);
            try
            {
                string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(Costs, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(_fileName, outputJSON + Environment.NewLine);
                Console.WriteLine("Запись выполнена!");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Запись не выполнена! Ошибка:\n{e.Message}");
            }
        }
        public ObservableCollection<Cost> GetCosts(string name, DateTime date)
        {
            LoadCosts();
            ObservableCollection<Cost> result = new ObservableCollection<Cost>();
            try
            {
                var list = Costs.Where(t => t.User.Name == name && t.Date == date);
                foreach (var el in list)
                {
                    result.Add(el);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
        public void AddCost(Cost cost)
        {
            if (_costs == null)
                _costs = new ObservableCollection<Cost>();
            if (FindCost(cost))
                _costs.First(t => t.User == cost.User && t.CostName.ToLower() == cost.CostName.ToLower() && cost.Date == t.Date).Sum += cost.Sum;
            else
                _costs.Add(cost);
            SaveCosts();
        }

        public void DeleteCost(Cost cost)
        {
            _costs.Remove(cost);
            SaveCosts();
        }
        public bool FindCost(Cost cost) => _costs.Any(el => el.CostName.ToLower() == cost.CostName.ToLower() && cost.Date == el.Date && el.User == cost.User);
        public double GetSum(string name, DateTime date)
        {
            double result = 0;
            foreach (var el in _costs.Where(t => t.User.Name == name && t.Date == date))
            {
                result += el.Sum;
            }
            return result;
        }
    }
}
