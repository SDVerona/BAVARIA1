using Data.Maps;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;


    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        
        }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=BAVARIA;Username=postgres;Password=1");
    
       
       public DbSet<Model> Models { get; set; }
       public DbSet<Typ> Types { get; set; }
       public DbSet<Option> Options { get; set; }
       public DbSet<OptionType> OptionTypes { get; set; }
       public DbSet<ModelOption> ModelOptions { get; set; }
       
        //dotnet tool install --global dotnet-ef
        //dotnet ef migrations add 'begin'
        //dotnet ef database update

        
        
    
        protected override void OnModelCreating(ModelBuilder model)
        {
           
            new ModelMap(model.Entity<Model>());
            new ModelOptionMap(model.Entity<ModelOption>());
            new OptionMap(model.Entity<Option>());
            new OptionTypeMap(model.Entity<OptionType>());
            new TypMap(model.Entity<Typ>()); 
            base.OnModelCreating(model);

        }

    
    }
