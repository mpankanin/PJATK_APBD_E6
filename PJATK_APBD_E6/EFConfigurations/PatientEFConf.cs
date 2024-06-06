using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PatientEFConf : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        throw new NotImplementedException();
    }
}