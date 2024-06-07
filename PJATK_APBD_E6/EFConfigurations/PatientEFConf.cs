using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PatientEFConf : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.IdPatient);
        builder.Property(p => p.FirstName).HasMaxLength(100);

        builder.Property(p => p.LastName).HasMaxLength(100);

        builder.Property(p => p.BirthDate);
    }
}