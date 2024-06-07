using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PrescriptionMedicamentEFConf : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        builder.Property(pm => pm.Dose);

        builder.Property(pm => pm.Details);

        builder.HasOne(ps => ps.PrescriptionNavigation)
            .WithMany(pm => pm.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ps => ps.MedicamentNavigation)
            .WithMany(pm => pm.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);
    }
}