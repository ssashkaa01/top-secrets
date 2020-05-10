namespace WCF_TopSecrets
{
    using System.Data.Entity;
    using WCF_TopSecrets.Entities;

    public partial class EFContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Secret> Secrets { get; set; }

        public EFContext() 
            : base("name=ModelDB")
        {
            Database.SetInitializer<EFContext>(new StoreDbInitializer());
        }    
  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Secret>()
               .HasRequired<User>(s => s.User)
               .WithMany(u => u.Secrets)
               .HasForeignKey<int>(s => s.UserId);
        }
    }
    
    public class StoreDbInitializer : DropCreateDatabaseAlways<EFContext>
    {
        protected override void Seed(EFContext db)
        {
            db.Users.Add(new User()
            { 
                Login = "demo",
                // sha512 : 12345
                Password = "fa585d89c851dd338a70dcf535aa2a92fee7836dd6aff1226583e88e0996293f16bc009c652826e0fc5c706695a03cddce372f139eff4d13959da6f1f5d3eabe",
                Name = "DemoName",
                Surname = "DemoSurname",
                Email = "demo@demo.com"
            });

            db.SaveChanges();
        }
    }
}
