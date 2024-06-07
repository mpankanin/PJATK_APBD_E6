using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJATK_APBD_E6.Contexts;
using PJATK_APBD_E6.DTOs;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private readonly AppDbContext _context;
    public PatientController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPatientDataByIdAsync(int id)
    {
        // get patient by id
        var patient = await _context.Patients.FindAsync(id);
        if (patient == null)
        {
            return NotFound("Patient not found.");
        }

        List<Prescription> prescriptions = await _context.Prescriptions
            .Where(prescription => prescription.IdPatient == id)
            .ToListAsync();
        
        List<GetPrescriptionDTO> prescriptionDtos = new List<GetPrescriptionDTO>();
        foreach (var prescription in prescriptions)
        {
            List<GetMedicamentDto> medicamentDtos = new List<GetMedicamentDto>();
            List<PrescriptionMedicament> prescriptionMedicaments = await _context.PrescriptionMedicaments
                .Where(prescriptionMedicament => prescriptionMedicament.IdPrescription == prescription.IdPrescription)
                .ToListAsync();
            foreach (var prescriptionMedicament in prescriptionMedicaments)
            {
                Medicament medicament = await _context.Medicaments.FindAsync(prescriptionMedicament.IdMedicament);
                medicamentDtos.Add(new GetMedicamentDto
                {
                    IdMedicament = medicament.IdMedicament,
                    Name = medicament.Name,
                    Dose = prescriptionMedicament.Dose,
                    Description = medicament.Description
                });
            }
            Doctor doctor = await _context.Doctors.FindAsync(prescription.IdDoctor);
            
            prescriptionDtos.Add(new GetPrescriptionDTO
            {
                IdPrescription = prescription.IdPrescription,
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Medicaments = medicamentDtos,
                Doctor = new GetDoctorDTO()
                {
                    IdDoctor = doctor.IdDoctor,
                    FirstName = doctor.FirstName
                }
            });
        }
        prescriptionDtos = prescriptionDtos.OrderBy(p => p.DueDate).ToList();
        
        GetPatientDataDTO patientData = new GetPatientDataDTO
        {
            IdPatient = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            Prescriptions = prescriptionDtos
        };
        
        return Ok(patientData);
    }

}