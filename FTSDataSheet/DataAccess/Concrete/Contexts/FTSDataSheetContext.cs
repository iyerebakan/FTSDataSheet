using DataAccess.Helpers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.Contexts
{
    public class FTSDataSheetContext : DbContext
    {
        public AppConfigurationHelper appConfiguration;
        public FTSDataSheetContext()
        {
            appConfiguration = new AppConfigurationHelper();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(appConfiguration.GetConnectionstring());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerUser> CustomerUsers { get; set; }
        public virtual DbSet<DataSheet> DataSheets { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<MailSetting> MailSettings { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<UserPasswordChange> UserPasswordChanges { get; set; }
    }
}
