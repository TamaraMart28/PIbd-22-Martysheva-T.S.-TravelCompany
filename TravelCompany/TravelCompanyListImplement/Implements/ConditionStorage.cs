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
    public class ConditionStorage : IConditionStorage
    {
        private readonly DataListSingleton source;

        public ConditionStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<ConditionViewModel> GetFullList()
        {
            var result = new List<ConditionViewModel>();
            foreach (var condition in source.Conditions)
            {
                result.Add(CreateModel(condition));
            }
            return result;
        }

        public List<ConditionViewModel> GetFilteredList(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<ConditionViewModel>();
            foreach (var condition in source.Conditions)
            {
                if (condition.ConditionName.Contains(model.ConditionName))
                {
                    result.Add(CreateModel(condition));
                }
            }
            return result;
        }

        public ConditionViewModel GetElement(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var condition in source.Conditions)
            {
                if (condition.Id == model.Id || condition.ConditionName == model.ConditionName)
                {
                    return CreateModel(condition);
                }
            }
            return null;
        }

        public void Insert(ConditionBindingModel model)
        {
            var tempCondition = new Condition { Id = 1 };
            foreach (var condition in source.Conditions)
            {
                if (condition.Id >= tempCondition.Id)
                {
                    tempCondition.Id = condition.Id + 1;
                }
            }
            source.Conditions.Add(CreateModel(model, tempCondition));
        }

        public void Update(ConditionBindingModel model)
        {
            Condition tempCondition = null;
            foreach (var condition in source.Conditions)
            {
                if (condition.Id == model.Id)
                {
                    tempCondition = condition;
                }
            }
            if (tempCondition == null)
            {
                throw new Exception("Условие не найдено");
            }
            CreateModel(model, tempCondition);
        }

        public void Delete(ConditionBindingModel model)
        {
            for (int i = 0; i < source.Conditions.Count; ++i)
            {
                if (source.Conditions[i].Id == model.Id.Value)
                {
                    source.Conditions.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Условие не найдено");
        }

        private static Condition CreateModel(ConditionBindingModel model, Condition condition)
        {
            condition.ConditionName = model.ConditionName;
            return condition;
        }

        private static ConditionViewModel CreateModel(Condition condition)
        {
            return new ConditionViewModel
            {
                Id = condition.Id,
                ConditionName = condition.ConditionName
            };
        }
    }
}
