using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyListImplement.Models;

namespace TravelCompanyListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Condition> Conditions { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }
        public List<Company> Companies { get; set; }
        public List<Client> Clients { get; set; }
        private DataListSingleton()
        {
            Conditions = new List<Condition>();
            Orders = new List<Order>();
            Travels = new List<Travel>();
            Companies = new List<Company>();
            Clients = new List<Client>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
