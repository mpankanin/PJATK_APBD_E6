namespace PJATK_APBD_E6.DTOs;

public class GetPrescriptionDTO
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<GetMedicamentDto> Medicaments { get; set; }
    public GetDoctorDTO Doctor { get; set; }
}