namespace Data.Migrations
{
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.BaseEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.BaseEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Employees.AddOrUpdate(x => x.EmployeeID,
                new Employee() {
                    EmployeeID = 1,
                    Name = "Admin",
                    CreatedDate = DateTime.Now,
                    CreatedBy = 0,
                    Description = "The Only Employee",
                    ModificationDate = DateTime.Now,
                    ModifiedBy = 0,
                    Email = "AdminMail",
                    IsDeleted = false,
                    Phone = "AdminPhone"
                }
            );
        }
    }
}
