using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TP4_.Models;

namespace TP4_.Data
{
    public class UniversityContext : Microsoft.EntityFrameworkCore.DbContext
    {
        private static UniversityContext universityContext=null; 
        private UniversityContext(DbContextOptions o ) : base (o) {     }

        public DbSet<Student> Student { get ; set ; }
        public static UniversityContext university_Context { get => universityContext; set => universityContext = Instantiate_UniversityContext(); }

        public static UniversityContext Instantiate_UniversityContext()
        {   if (universityContext == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
                optionsBuilder.UseSqlite("Data Source=../database.db");
                Debug.WriteLine("Une nouvelle instance de UniversityContext");
                universityContext= new UniversityContext(optionsBuilder.Options);
                return universityContext;
            }

            Debug.WriteLine("Une instance de UniversityContext deja existante");
            return universityContext;
        }

       

    }
}
