using Microsoft.EntityFrameworkCore;

namespace LISTA_TAREFA_API.Models
{
    public class DbLTContext : DbContext
    {
        public DbLTContext(DbContextOptions<DbLTContext> options) : base(options)
        {

        }

        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            List<Entities.Task> tasks = new List<Entities.Task>();

            for (int i = 0; i < 50; i++)
            {
                tasks.Add(
                    new Entities.Task() 
                    { 
                        Id = i+1,
                        Cost = i, 
                        LimitDate = DateTime.Now.AddDays(20), 
                        Name = $"TAREFA {i}", 
                        Order = i 
                    });
            };
            modelBuilder.Entity<Entities.Task>().HasData(tasks);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
