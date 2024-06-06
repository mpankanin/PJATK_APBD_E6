using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PJATK_APBD_E6.Models;

public class Doctor
{   
    public int IdDoctor { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    
    public virtual ICollection<Prescription> Prescriptions { get; set; }
}