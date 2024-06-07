using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.DTOs;

public class AddPrescriptionDTO
{
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public AddPatientDTO PatientDto { get; set; }
    public int IdDoctor { get; set; }
    public ICollection<int> MedicamentIds { get; set; }
}