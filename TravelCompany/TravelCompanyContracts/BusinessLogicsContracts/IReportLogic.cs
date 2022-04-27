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


        // Получение списка хранилищ с указанием, какие в них есть условия
        List<ReportCompanyConditionViewModel> GetCompanyCondition();

        // Получение списка заказов, объединенных по датам
        List<ReportOrdersByDateViewModel> GetOrdersByDate();

        // Сохранение хранилищ в файл-Word
        void SaveCompaniesToWordFile(ReportBindingModel model);

        // Сохранение хранилищ с указаеним условий в файл-Excel
        void SaveCompanyConditionToExcelFile(ReportBindingModel model);

        // Сохранение заказов, объединенных по датам, в файл-Pdf
        void SaveOrdersByDateToPdfFile(ReportBindingModel model);
    }
}
