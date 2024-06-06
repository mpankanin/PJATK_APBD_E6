using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class MedicamentEFConf : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMedicament);
        builder.Property(m => m.IdMedicament).ValueGeneratedOnAdd();

        builder.Property(m => m.Name).HasMaxLength(100);

        builder.Property(m => m.Type).HasMaxLength(100);
    }
}