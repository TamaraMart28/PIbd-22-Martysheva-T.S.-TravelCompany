using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelCompanyBusinessLogic.BusinessLogics;
using TravelCompanyContracts.BusinessLogicsContracts;
using TravelCompanyContracts.StoragesContracts;
using TravelCompanyFileImplement.Implements;
using Unity;
using Unity.Lifetime;

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

            currentContainer.RegisterType<IConditionLogic, ConditionLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IOrderLogic, OrderLogic>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<ITravelLogic, TravelLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
