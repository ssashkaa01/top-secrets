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
  
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Secret>()
        //       .HasRequired<User>(s => s.User)
        //       .WithMany(u => u.Secrets)
        //       .HasForeignKey<int>(s => s.UserId);
        //}
    }
    
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<EFContext>
    {
        protected override void Seed(EFContext db)
        {
            BLL.User userBLL = new BLL.User();

            userBLL.Create("demo", "12345678");
          
        }
    }
}
