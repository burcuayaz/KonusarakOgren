
using Microsoft.EntityFrameworkCore;
using Web.UI.Models;

namespace Web.UI.Data
{
   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }

            public DbSet<Exam> Exam { get; set; }

            public DbSet<Question> Question { get; set; }

            public DbSet<ExamResult> ExamResult { get; set; }
    }
   
}
