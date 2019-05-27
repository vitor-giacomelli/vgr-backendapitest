using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacationRental.Contact.Api.Models
{
    public class ContactViewModelContext : DbContext
    {

        public ContactViewModelContext(DbContextOptions options)
           : base(options)
        {
        }
        public ContactViewModelContext() : base(GetOptions("Contacts"))
        {

        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            var options =  SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            return options;
        }

        public DbSet<ContactViewModel> Contacts { get; set; }
    }
}
