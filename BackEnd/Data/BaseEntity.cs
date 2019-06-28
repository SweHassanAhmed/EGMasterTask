namespace Data
{
    using Model.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BaseEntity : DbContext
    {
        public BaseEntity()
            : base("name=BaseEntity")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Call> Calls { get; set; }

    }
   
}