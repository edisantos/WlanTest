using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WlanTestSystem.Application.ModelView;

namespace WlanTestSystem.Infra.Data.EntityConfiguration
{
    public class MagazineSizeConfiguration:EntityTypeConfiguration<MagazineSize>
    {
        public MagazineSizeConfiguration()
        {
            ToTable("MagazineSize");

            HasKey(p => p.MagazineSizeId);

            Property(p => p.Data)
                .HasColumnType("datetime")
                .IsRequired();

            Property(p => p.Operador)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            Property(p => p.Size)
               .HasColumnType("int")
               .IsRequired();
        }
    }
}
