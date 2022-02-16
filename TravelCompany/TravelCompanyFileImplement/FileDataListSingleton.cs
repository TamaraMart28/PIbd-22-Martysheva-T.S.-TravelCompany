﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.Enums;
using TravelCompanyFileImplement.Models;
using System.IO;
using System.Xml.Linq;


namespace TravelCompanyFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ConditionFileName = "Condition.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string TravelFileName = "Travel.xml";
        public List<Condition> Conditions { get; set; }
        public List<Order> Orders { get; set; }
        public List<Travel> Travels { get; set; }

        private FileDataListSingleton()
        {
            Conditions = LoadConditions();
            Orders = LoadOrders();
            Travels = LoadTravels();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }

        ~FileDataListSingleton()
        {
            SaveConditions();
            SaveOrders();
            SaveTravels();
        }

        private List<Condition> LoadConditions()
        {
            var list = new List<Condition>();
            if (File.Exists(ConditionFileName))
            {
                var xDocument = XDocument.Load(ConditionFileName);
                var xElements = xDocument.Root.Elements("Condition").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Condition
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ConditionName = elem.Element("ConditionName").Value
                    });
                }
            }
            return list;
        }

        private List<Order> LoadOrders()
        {
            // прописать логику
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                var xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelId = Convert.ToInt32(elem.Element("TravelId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? 
                        (DateTime?)null : Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }

        private List<Travel> LoadTravels()
        {
            var list = new List<Travel>();
            if (File.Exists(TravelFileName))
            {
                var xDocument = XDocument.Load(TravelFileName);
                var xElements = xDocument.Root.Elements("Travel").ToList();
                foreach (var elem in xElements)
                {
                    var travCond = new Dictionary<int, int>();
                    foreach (var condition in elem.Element("TravelConditions").Elements("TravelCondition").ToList())
                    {
                        travCond.Add(Convert.ToInt32(condition.Element("Key").Value), Convert.ToInt32(condition.Element("Value").Value));
                    }
                    list.Add(new Travel
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        TravelName = elem.Element("TravelName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        TravelConditions = travCond
                    });
                }
            }
            return list;
        }

        private void SaveConditions()
        {
            if (Conditions != null)
            {
                var xElement = new XElement("Conditions");
                foreach (var condition in Conditions)
                {
                    xElement.Add(new XElement("Condition",
                    new XAttribute("Id", condition.Id),
                    new XElement("ConditionName", condition.ConditionName)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(ConditionFileName);
            }
        }

        private void SaveOrders()
        {
            // прописать логику
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                        new XAttribute("Id", order.Id),
                        new XElement("TravelId", order.TravelId),
                        new XElement("Count", order.Count),
                        new XElement("Sum", order.Sum),
                        new XElement("Status", order.Status),
                        new XElement("DateCreate", order.DateCreate),
                        new XElement("DateImplement", order.DateImplement)));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }

        private void SaveTravels()
        {
            if (Travels != null)
            {
                var xElement = new XElement("Travels");
                foreach (var travel in Travels)
                {
                    var condElement = new XElement("TravelConditions");
                    foreach (var condition in travel.TravelConditions)
                    {
                        condElement.Add(new XElement("TravelCondition",
                        new XElement("Key", condition.Key),
                        new XElement("Value", condition.Value)));
                    }
                    xElement.Add(new XElement("Travel",
                     new XAttribute("Id", travel.Id),
                     new XElement("TravelName", travel.TravelName),
                     new XElement("Price", travel.Price),
                     condElement));
                }
                var xDocument = new XDocument(xElement);
                xDocument.Save(TravelFileName);
            }
        }
    }
}
