using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLib;

namespace DR_Rest.Managers
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) :
            base(options)
        {
            //
        }
        public DbSet<Model> Records { get; set; }
    }

}

