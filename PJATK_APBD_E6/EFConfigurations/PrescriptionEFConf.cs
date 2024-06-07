using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PrescriptionEFConf : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription);
        builder.Property(p => p.IdPrescription);

        builder.Property(p => p.Date);

        builder.Property(p => p.DueDate);

        builder.HasOne(p => p.DoctorNavigator)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.PatientNavigator)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);
    }
}