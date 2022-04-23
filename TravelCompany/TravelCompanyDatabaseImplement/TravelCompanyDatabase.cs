using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelCompanyDatabaseImplement
{
    public class TravelCompanyDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=Tamara-PC\SQLEXPRESS;Initial Catalog=TravelCompanyDatabaseComp;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Condition> Conditions { set; get; }
        public virtual DbSet<Travel> Travels { set; get; }
        public virtual DbSet<TravelCondition> TravelConditions { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
        public virtual DbSet<Company> Companies { set; get; }
        public virtual DbSet<CompanyCondition> CompanyConditions { set; get; }
        public virtual DbSet<Client> Clients { set; get; }
    }
}
