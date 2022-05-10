using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyBusinessLogic.BusinessLogics;
using TravelCompanyBusinessLogic.MailWorker;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyDatabaseImplement.Implements;
using TravelCompanyBusinessLogic.OfficePackage;
using TravelCompanyBusinessLogic.OfficePackage.Implements;
using TravelCompanyContracts.BindingModels;
using Unity;
using Unity.Lifetime;
using System.Configuration;
using System.Threading;

namespace TravelCompanyView
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = BuildUnityContainer();
                }
                return container;
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            var mailSender = Container.Resolve<AbstractMailWorker>();
            mailSender.MailConfig(new MailConfigBindingModel
            {
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort = Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"])
            });

            // ������� ������
            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), null, 0, 100000);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            
            currentContainer.RegisterType<IConditionStorage, ConditionStorage>(new HierarchicalLifetimeManager());
            
            currentContainer.RegisterType<IOrderStorage, OrderStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ITravelStorage, TravelStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ICompanyStorage, CompanyStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IClientStorage, ClientStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IImplementerStorage, ImplementerStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IMessageInfoStorage, MessageInfoStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IConditionLogic, ConditionLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ITravelLogic, TravelLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ICompanyLogic, CompanyLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IClientLogic, ClientLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IMessageInfoLogic, MessageInfoLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IWorkProcess, WorkModeling>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractMailWorker, MailKitWorker>(new SingletonLifetimeManager());

            currentContainer.RegisterType<IReportLogic, ReportLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToWord, SaveToWord>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToExcel, SaveToExcel>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<AbstractSaveToPdf, SaveToPdf>(new HierarchicalLifetimeManager());

            return currentContainer;
        }

        private static void MailCheck(object obj) => container.Resolve<AbstractMailWorker>().MailCheck();
    }
}
