using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PrescriptionEFConf : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        throw new NotImplementedException();
    }
}