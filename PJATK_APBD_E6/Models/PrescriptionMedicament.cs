using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PJATK_APBD_E6.Models;

public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    
    public int IdPrescription { get; set; }
    
    public int Dose { get; set; }
    
    public string Details { get; set; }
    
    
    public Medicament MedicamentNavigation { get; set; }
    public Prescription PrescriptionNavigation { get; set; }
}