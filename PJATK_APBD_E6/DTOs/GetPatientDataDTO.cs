namespace PJATK_APBD_E6.DTOs;

public class GetPatientDataDTO
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public ICollection<GetPrescriptionDTO> Prescriptions { get; set; }
}