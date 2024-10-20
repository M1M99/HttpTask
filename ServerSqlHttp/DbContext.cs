using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSqlHttp
{
    internal class DbContext1 : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NB7MT4D\\SQLEXPRESS;Initial Catalog=ServerHttp;Integrated Security=True;Trust Server Certificate=True");
        }
        public DbSet<User> users { get; set; }
    }
}

