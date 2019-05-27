using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WlanTestSystem.Application.ModelView;
using WlanTestSystem.Infra.Data.EntityConfiguration;

namespace WlanTestSystem.Infra.Data.Contexto
{
    public class DataContexto:DbContext
    {
       
        public DataContexto()
            :base(@"Data Source=DESKTOP-1Q2TUU2\LEMOSDATABASE;Initial Catalog=DemoDatabase;Integrated Security=True")
        {

        }

        public DbSet<TB_WLAN> TB_WLAN { get; set; }
        public DbSet<MagazineSize> MagazineSize { get; set; }
        public DbSet<WlanTestVerification> WlanTestVerification { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new TB_WLANConfiguration());
            modelBuilder.Configurations.Add(new MagazineSizeConfiguration());
            modelBuilder.Configurations.Add(new WlanTesteVerificationConfiguration());

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
            modelBuilder.Properties<string>()
               .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            base.OnModelCreating(modelBuilder);
        }
    }
}
