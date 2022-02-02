using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyListImplement.Models;


namespace TravelCompanyListImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
        private readonly DataListSingleton source;

        public TravelStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<TravelViewModel> GetFullList()
        {
            var result = new List<TravelViewModel>();
            foreach (var travel in source.Travels)
            {
                result.Add(CreateModel(travel));
            }
            return result;
        }

        public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<TravelViewModel>();
            foreach (var travel in source.Travels)
            {
                if (travel.TravelName.Contains(model.TravelName))
                {
                    result.Add(CreateModel(travel));
                }
            }
            return result;
        }

        public TravelViewModel GetElement(TravelBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var travel in source.Travels)
            {
                if (travel.Id == model.Id || travel.TravelName == model.TravelName)
                {
                    return CreateModel(travel);
                }
            }
            return null;
        }

        public void Insert(TravelBindingModel model)
        {
            var tempTravel = new Travel
            {
                Id = 1,
                TravelConditions = new Dictionary<int, int>()
            };
            foreach (var travel in source.Travels)
            {
                if (travel.Id >= tempTravel.Id)
                {
                    tempTravel.Id = travel.Id + 1;
                }
            }
            source.Travels.Add(CreateModel(model, tempTravel));
        }

        public void Update(TravelBindingModel model)
        {
            Travel tempTravel = null;
            foreach (var travel in source.Travels)
            {
                if (travel.Id == model.Id)
                {
                    tempTravel = travel;
                }
            }
            if (tempTravel == null)
            {
                throw new Exception("Путевка не найдена");
            }
            CreateModel(model, tempTravel);
        }

        public void Delete(TravelBindingModel model)
        {
            for (int i = 0; i < source.Travels.Count; ++i)
            {
                if (source.Travels[i].Id == model.Id)
                {
                    source.Travels.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Путевка не найдена");
        }

        private static Travel CreateModel(TravelBindingModel model, Travel travel)
        {
            travel.TravelName = model.TravelName;
            travel.Price = model.Price;
            // удаляем убранные
            foreach (var key in travel.TravelConditions.Keys.ToList())
            {
                if (!model.TravelConditions.ContainsKey(key))
                {
                    travel.TravelConditions.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var condition in model.TravelConditions)
            {
                if (travel.TravelConditions.ContainsKey(condition.Key))
                {
                    travel.TravelConditions[condition.Key] = model.TravelConditions[condition.Key].Item2;
                }
                else
                {
                    travel.TravelConditions.Add(condition.Key, model.TravelConditions[condition.Key].Item2);
                }
            }
            return travel;
        }

        private TravelViewModel CreateModel(Travel travel)
        {
            // требуется дополнительно получить список условий для путевки с названиями и их количество
            var travelConditions = new Dictionary<int, (string, int)>();
            foreach (var tc in travel.TravelConditions)
            {
                string conditionName = string.Empty;
                foreach (var condition in source.Conditions)
                {
                    if (tc.Key == condition.Id)
                    {
                        conditionName = condition.ConditionName;
                        break;
                    }
                }
                travelConditions.Add(tc.Key, (conditionName, tc.Value));
            }
            return new TravelViewModel
            {
                Id = travel.Id,
                TravelName = travel.TravelName,
                Price = travel.Price,
                TravelConditions = travelConditions
            };
        }
    }
}
