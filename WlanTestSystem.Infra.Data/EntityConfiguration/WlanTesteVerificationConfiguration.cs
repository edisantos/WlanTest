using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WlanTestSystem.Application.ModelView;

namespace WlanTestSystem.Infra.Data.EntityConfiguration
{
    public class WlanTesteVerificationConfiguration:EntityTypeConfiguration<WlanTestVerification>
    {
        public WlanTesteVerificationConfiguration()
        {
            ToTable("WlanTesteVerification");

            HasKey(p => p.WlanTesteVerificationId);

            Property(p => p.SN)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.TEST_END_TIME)
              .HasColumnType("datetime")
              .IsRequired();

            Property(p => p.BT_MAC)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.WIFI_MAC)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.RESULT)
                .HasColumnType("varchar")
                .HasMaxLength(1)
                .IsRequired();

            //Property(p => p.StatusWlan)
            //    .HasColumnType("bool")
            //    .IsRequired();

            Property(p => p.VEND_CODE)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            HasRequired(p => p.MagazineSize)
                .WithMany(p => p.WlanTestVerification)
                .HasForeignKey(p => p.MagazineSizeId);
        }
    }
}
