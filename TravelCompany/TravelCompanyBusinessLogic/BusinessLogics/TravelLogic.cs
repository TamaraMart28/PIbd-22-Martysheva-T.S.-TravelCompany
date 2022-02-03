using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogics
{
    public class TravelLogic : ITravelLogic
    {
        private readonly ITravelStorage _travelStorage;

        public TravelLogic(ITravelStorage travelStorage)
        {
            _travelStorage = travelStorage;
        }

        public List<TravelViewModel> Read(TravelBindingModel model)
        {
            if (model == null)
            {
                return _travelStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TravelViewModel> { _travelStorage.GetElement(model) };
            }
            return _travelStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TravelBindingModel model)
        {
            var element = _travelStorage.GetElement(new TravelBindingModel
            {
                TravelName = model.TravelName,
                Price = model.Price,
                TravelConditions = model.TravelConditions
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть путевка с таким названием");
            }
            if (model.Id.HasValue)
            {
                _travelStorage.Update(model);
            }
            else
            {
                _travelStorage.Insert(model);
            }
        }

        public void Delete(TravelBindingModel model)
        {
            var element = _travelStorage.GetElement(new TravelBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Путевка не найдена");
            }
            _travelStorage.Delete(model);
        }
    }
}
