using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class ConditionStorage : IConditionStorage
    {
        public List<ConditionViewModel> GetFullList()
        {
            using var context = new TravelCompanyDatabase();
            return context.Conditions
            .Select(CreateModel)
            .ToList();
        }

        public List<ConditionViewModel> GetFilteredList(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new TravelCompanyDatabase();
            return context.Conditions
            .Where(rec => rec.ConditionName.Contains(model.ConditionName))
            .Select(CreateModel)
            .ToList();
        }

        public ConditionViewModel GetElement(ConditionBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new TravelCompanyDatabase();
            var condition = context.Conditions
            .FirstOrDefault(rec => rec.ConditionName == model.ConditionName || rec.Id == model.Id);

            return condition != null ? CreateModel(condition) : null;
        }

        public void Insert(ConditionBindingModel model)
        {
            using var context = new TravelCompanyDatabase();
            context.Conditions.Add(CreateModel(model, new Condition()));
            context.SaveChanges();
        }

        public void Update(ConditionBindingModel model)
        {
            using var context = new TravelCompanyDatabase();
            var element = context.Conditions.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(ConditionBindingModel model)
        {
            using var context = new TravelCompanyDatabase();
            Condition element = context.Conditions.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Conditions.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
