using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class DoctorEFConf : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(doctor => doctor.IdDoctor);
        builder.Property(doctor => doctor.IdDoctor).ValueGeneratedOnAdd();

        builder.Property(doctor => doctor.FirstName).HasMaxLength(100);

        builder.Property(doctor => doctor.LastName).HasMaxLength(100);

        builder.Property(doctor => doctor.Email).HasMaxLength(100);
    }
}