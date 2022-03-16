using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyBusinessLogic.OfficePackage;
using TravelCompanyBusinessLogic.OfficePackage.HelperModels;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyContracts.ViewModels;

namespace TravelCompanyBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IConditionStorage _conditionStorage;
        private readonly ITravelStorage _travelStorage;
        private readonly IOrderStorage _orderStorage;

        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(ITravelStorage travelStorage, IConditionStorage conditionStorage, IOrderStorage orderStorage, 
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _travelStorage = travelStorage;
            _conditionStorage = conditionStorage;
            _orderStorage = orderStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }
        
        // Получение списка путевок с указанием условий в них
        public List<ReportTravelConditionViewModel> GetTravelCondition()
        {
            var travels = _travelStorage.GetFullList();
            var list = new List<ReportTravelConditionViewModel>();

            foreach (var travel in travels)
            {
                var record = new ReportTravelConditionViewModel
                {
                    TravelName = travel.TravelName,
                    Conditions = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var condition in travel.TravelConditions)
                {
                    record.Conditions.Add(new Tuple<string, int>(condition.Value.Item1, condition.Value.Item2));
                    record.TotalCount += condition.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }
        
        // Получение списка заказов за определенный период
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                TravelName = x.TravelName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
        }

        // Сохранение путевок в файл-Word
        public void SaveTravelsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                Travels = _travelStorage.GetFullList()
            });
        }

        // Сохранение путевок с указаеним условий в файл-Excel
        public void SaveTravelConditionToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список путевок",
                TravelConditions = GetTravelCondition()
            });
        }

        // Сохранение заказов в файл-Pdf
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
