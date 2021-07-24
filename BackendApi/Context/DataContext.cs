using BackendApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        {
        }

        public DbSet<UserModel> User { get; set; } //same name as in DB !!!
        public DbSet<ReviewModel> Review { get; set; }

        public DbSet<MuseumModel> Museum { get; set; }


    }
}
