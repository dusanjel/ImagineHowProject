using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagineHowProject.Models
{
    public class ImagineHowProjectContext : DbContext
    {
        public ImagineHowProjectContext(DbContextOptions<ImagineHowProjectContext> options)
            : base(options)
        { }

        public DbSet<Product> Products { get; set; }
    }
}
