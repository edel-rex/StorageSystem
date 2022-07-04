using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using  WebAPI.Models;

    public class AppContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public AppContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

  
        public AppContext (DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.Users>? Users { get; set; }

        public DbSet<WebAPI.Models.Storages>? Storages { get; set; }
    }
