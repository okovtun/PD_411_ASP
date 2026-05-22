using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class MVCContext : DbContext
    {
        public MVCContext (DbContextOptions<MVCContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Student> Students { get; set; } = default!;
        public DbSet<MVC.Models.Course> Courses { get; set; } = default!;
        public DbSet<MVC.Models.Enrollment> Enrollments { get; set; } = default!;

	}
}
