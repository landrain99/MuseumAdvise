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

        public DbSet<UserModelWebSite> UserItem { get; set; }
        public DbSet<ReviewModelWebSite> Review { get; set; }

        //public DbSet<MuseumModel> Museum { get; set; }
    }
}
