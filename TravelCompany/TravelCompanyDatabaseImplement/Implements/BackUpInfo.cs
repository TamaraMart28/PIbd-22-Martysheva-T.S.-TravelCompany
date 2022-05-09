using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyContracts.StoragesContracts;
using System.Reflection;

namespace TravelCompanyDatabaseImplement.Implements
{
    public class BackUpInfo : IBackUpInfo
    {
        public Assembly GetAssembly() => typeof(BackUpInfo).Assembly;

        public List<PropertyInfo> GetFullList()
        {
            using var context = new TravelCompanyDatabase();
            var type = context.GetType();
            return type.GetProperties().Where(x =>
            x.PropertyType.FullName.StartsWith("Microsoft.EntityFrameworkCore.DbSet")).ToList();
        }

        public List<T> GetList<T>() where T : class, new()
        {
            using var context = new TravelCompanyDatabase();
            return context.Set<T>().ToList();
        }
    }
}
