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
    public class CompanyStorage : ICompanyStorage
    {
		public List<CompanyViewModel> GetFullList()
		{
			using var context = new TravelCompanyDatabase();

			return context.Companies
			.Include(rec => rec.CompanyConditions)
			.ThenInclude(rec => rec.Condition)
			.ToList()
			.Select(CreateModel)
			.ToList();
		}

		public List<CompanyViewModel> GetFilteredList(CompanyBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			using var context = new TravelCompanyDatabase();

			return context.Companies
			.Include(rec => rec.CompanyConditions)
			.ThenInclude(rec => rec.Condition)
			.Where(rec => rec.CompanyName.Contains(model.CompanyName))
			.ToList()
			.Select(CreateModel)
			.ToList();
		}

		public CompanyViewModel GetElement(CompanyBindingModel model)
		{
			if (model == null)
			{
				return null;
			}

			using var context = new TravelCompanyDatabase();

			var company = context.Companies
			.Include(rec => rec.CompanyConditions)
			.ThenInclude(rec => rec.Condition)
			.FirstOrDefault(rec => rec.CompanyName == model.CompanyName || rec.Id == model.Id);

			return company != null ? CreateModel(company) : null;
		}

		public void Insert(CompanyBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				Company company = new Company()
				{
					CompanyName = model.CompanyName,
					NameResponsible = model.NameResponsible,
					DateCreate = model.DateCreate
				};
				context.Companies.Add(company);
				context.SaveChanges();
				CreateModel(model, company, context);
				transaction.Commit();
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public void Update(CompanyBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var element = context.Companies.FirstOrDefault(rec => rec.Id == model.Id);

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

		public void Delete(CompanyBindingModel model)
		{
			using var context = new TravelCompanyDatabase();
			Company element = context.Companies.FirstOrDefault(rec => rec.Id == model.Id);

			if (element != null)
			{
				context.Companies.Remove(element);
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Элемент не найден");
			}
		}

		private static Company CreateModel(CompanyBindingModel model, Company company, TravelCompanyDatabase context)
		{
			company.CompanyName = model.CompanyName;
			company.NameResponsible = model.NameResponsible;
			company.DateCreate = model.DateCreate;

			if (model.Id.HasValue)
			{
				var companyConditions = context.CompanyConditions.Where(rec => rec.CompanyId == model.Id.Value).ToList();
				// удалили те, которых нет в модели
				context.CompanyConditions.RemoveRange(companyConditions.Where(rec => !model.CompanyConditions.ContainsKey(rec.ConditionId)).ToList());
				context.SaveChanges();
				// обновили количество у существующих записей
				foreach (var updateCondition in companyConditions)
				{
					updateCondition.Count = model.CompanyConditions[updateCondition.ConditionId].Item2;
					model.CompanyConditions.Remove(updateCondition.ConditionId);
				}
				context.SaveChanges();
			}
			// добавили новые
			foreach (var cc in model.CompanyConditions)
			{
				context.CompanyConditions.Add(new CompanyCondition
				{
					CompanyId = company.Id,
					ConditionId = cc.Key,
					Count = cc.Value.Item2
				});
				context.SaveChanges();
			}

			return company;
		}

		private static CompanyViewModel CreateModel(Company company)
		{
			return new CompanyViewModel
			{
				Id = company.Id,
				CompanyName = company.CompanyName,
				NameResponsible = company.NameResponsible,
				DateCreate = company.DateCreate,
				CompanyConditions = company.CompanyConditions
				.ToDictionary(recCC => recCC.ConditionId,
				recCC => (recCC.Condition?.ConditionName, recCC.Count))
			};
		}

		public bool CheckAndTake(Dictionary<int, (string, int)> conditions, int countNeed)
		{
			using var context = new TravelCompanyDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				foreach (var cond in conditions)
				{
					int count = cond.Value.Item2 * countNeed;
					var company = context.CompanyConditions.Where(rec => rec.ConditionId == cond.Key);

					foreach (var comp in company)
					{
						if (comp.Count <= count)
						{
							count -= comp.Count;
							context.CompanyConditions.Remove(comp);
						}
						else
						{
							comp.Count -= count;
							count = 0;
						}

						if (count == 0)
						{
							break;
						}
					}
					if (count != 0)
					{
						throw new Exception("Недостаточно условий для путевок");
					}
				}

				context.SaveChanges();
				transaction.Commit();
				return true;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}
	}
}
