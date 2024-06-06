using Microsoft.EntityFrameworkCore;
using PJATK_APBD_E6.EFConfigurations;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
    
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DoctorEFConf());
        modelBuilder.ApplyConfiguration(new MedicamentEFConf());
        modelBuilder.ApplyConfiguration(new PatientEFConf());
        modelBuilder.ApplyConfiguration(new PrescriptionEFConf());
        modelBuilder.ApplyConfiguration(new PrescriptionMedicamentEFConf());
    }
}