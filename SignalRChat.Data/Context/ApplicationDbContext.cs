using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalRChat.Entity.Concrete;

namespace SignalRChat.Data.Context
{
    public class ApplicationDbContext : BaseContext<ApplicationDbContext>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = configBuilder.Build();



            string cnnStr = "";

            cnnStr = configuration.GetValue<string>("ConnectionStrings:ChatApp");

            optionsBuilder.UseSqlServer(cnnStr);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<Message>().ToTable("Messages");

            builder.Entity<Message>()
                .HasOne<User>(a => a.Sender)
                .WithMany(d => d.Messages)
                .HasForeignKey(d => d.SenderId);
        }
    }
}
