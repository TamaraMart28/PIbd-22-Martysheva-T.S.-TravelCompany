using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;
using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class TravelStorage : ITravelStorage
    {
		public List<TravelViewModel> GetFullList()
		{
			using var context = new TravelCompanyDatabase();

			return context.Travels
			.Include(rec => rec.TravelConditions)
			.ThenInclude(rec => rec.Condition)
			.ToList()
			.Select(CreateModel)
			.ToList();
		}

		public List<TravelViewModel> GetFilteredList(TravelBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			using var context = new TravelCompanyDatabase();

			return context.Travels
			.Include(rec => rec.TravelConditions)
			.ThenInclude(rec => rec.Condition)
			.Where(rec => rec.TravelName.Contains(model.TravelName))
			.ToList()
			.Select(CreateModel)
			.ToList();
		}

		public TravelViewModel GetElement(TravelBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			using var context = new TravelCompanyDatabase();

			var travel = context.Travels
			.Include(rec => rec.TravelConditions)
			.ThenInclude(rec => rec.Condition)
			.FirstOrDefault(rec => rec.TravelName == model.TravelName || rec.Id == model.Id);

			return travel != null ? CreateModel(travel) : null;
		}

		public void Insert(TravelBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				Travel travel = new Travel()
				{
					TravelName = model.TravelName,
					Price = model.Price
				};
				context.Travels.Add(travel);
				context.SaveChanges();
				CreateModel(model, travel, context);
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public void Update(TravelBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var element = context.Travels.FirstOrDefault(rec => rec.Id == model.Id);

				if (element == null)
				{
					throw new Exception("Элемент не найден");
				}
				CreateModel(model, element, context);
				context.SaveChanges();

				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public void Delete(TravelBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			Travel element = context.Travels.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Travels.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		private static Travel CreateModel(TravelBindingModel model, Travel travel, TravelCompanyDatabase context)
		{
			travel.TravelName = model.TravelName;
			travel.Price = model.Price;

			if (model.Id.HasValue)
			{
				var travelConditions = context.TravelConditions.Where(rec => rec.TravelId == model.Id.Value).ToList();
				// удалили те, которых нет в модели
				context.TravelConditions.RemoveRange(travelConditions.Where(rec => !model.TravelConditions.ContainsKey(rec.ConditionId)).ToList());
				context.SaveChanges();
				// обновили количество у существующих записей
				foreach (var updateCondition in travelConditions)
				{
					updateCondition.Count = model.TravelConditions[updateCondition.ConditionId].Item2;
					model.TravelConditions.Remove(updateCondition.ConditionId);
				}
				context.SaveChanges();
			}
			// добавили новые
			foreach (var tc in model.TravelConditions)
			{
				context.TravelConditions.Add(new TravelCondition
				{
					TravelId = travel.Id,
					ConditionId = tc.Key,
					Count = tc.Value.Item2
				});
				context.SaveChanges();
			}

			return travel;
		}

		private static TravelViewModel CreateModel(Travel travel)
		{
			return new TravelViewModel
			{
				Id = travel.Id,
				TravelName = travel.TravelName,
				Price = travel.Price,
				TravelConditions = travel.TravelConditions
				.ToDictionary(recTC => recTC.ConditionId,
				recTC => (recTC.Condition?.ConditionName, recTC.Count))
			};
		}
	}
}
