using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.EFConfigurations;

public class PrescriptionMedicamentEFConf : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        throw new NotImplementedException();
    }
}