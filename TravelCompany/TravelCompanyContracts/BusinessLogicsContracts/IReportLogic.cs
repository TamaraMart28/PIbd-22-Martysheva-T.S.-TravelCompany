using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.BindingModels;
using TravelCompanyContracts.ViewModels;


namespace TravelCompanyContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        // Получение списка путевок с указанием, какие в них есть условия
        List<ReportTravelConditionViewModel> GetTravelCondition();

        // Получение списка заказов за определенный период
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        // Сохранение путевок в файл-Word
        void SaveTravelsToWordFile(ReportBindingModel model);

        // Сохранение путевок с указаеним условий в файл-Excel
        void SaveTravelConditionToExcelFile(ReportBindingModel model);

        // Сохранение заказов в файл-Pdf
        void SaveOrdersToPdfFile(ReportBindingModel model);
    }
}
