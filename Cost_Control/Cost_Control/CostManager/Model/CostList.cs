using System.Text.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Cost_Control.CostManager.Model
{
    [Serializable]
    public static class CostList
    {
        private static string _fileName = "JsonCosts.json";
        private static ObservableCollection<Cost> _costs = LoadCosts();
        public static ObservableCollection<Cost> Costs
        {
            get => _costs;
        }
        public static ObservableCollection<Cost> LoadCosts()
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
            return _costs;
        }

        public static void SaveCosts()
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
        public static ObservableCollection<Cost> GetCosts(string name, DateTime date)
        {

            ObservableCollection<Cost> result = new ObservableCollection<Cost>();
            try
            {
                var list = Costs.Where(t => t.User.Name == name && t.Date.ToString("d") == date.ToString("d"));
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
        public static void AddCost(Cost cost)
        {
            if (_costs == null)
                _costs = new ObservableCollection<Cost>();
            if (FindCost(cost))
                _costs.First(t => t.CostName.ToLower() == cost.CostName.ToLower() && cost.Date.ToString("d") == t.Date.ToString("d")).Sum += cost.Sum;
            else
                _costs.Add(cost);
        }

        public static void DeleteCost(Cost cost) => _costs.Remove(cost);

        public static bool FindCost(Cost cost)
        {
            foreach (var el in _costs)
            {
                if (el.CostName.ToLower() == cost.CostName.ToLower() && cost.Date.ToString("d") == el.Date.ToString("d") && UserList.FindUser(el.User))
                    return true;
            }
            return false;
        }
        public static double GetSum(string name, DateTime date)
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
