using System.Data.Entity.ModelConfiguration;
using WlanTestSystem.Application.ModelView;

namespace WlanTestSystem.Infra.Data.EntityConfiguration
{
    public class TB_WLANConfiguration:EntityTypeConfiguration<TB_WLAN>
    {
        public TB_WLANConfiguration()
        {
            ToTable("TB_WLAN");

            HasKey(p => p.WlanId);

            Property(p => p.SN)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.MAC)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(p => p.WIFI_MAC)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(p => p.BT_MAC)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(p => p.Data)
               .HasColumnType("datetime")
               .IsRequired();

            Property(p => p.StatusTest)
               .HasColumnType("int")
               .IsRequired();


            Property(p => p.VEND_CODE)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

        }
    }
}
