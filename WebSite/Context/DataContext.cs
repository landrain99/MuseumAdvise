using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Context
{
    public class DataContext : DbContext
    {
        public 
            DataContext(DbContextOptions<DataContext> opt)
                : base(opt)
        {
        }

        public DbSet<UserModel> UserItem { get; set; }
    }
}
