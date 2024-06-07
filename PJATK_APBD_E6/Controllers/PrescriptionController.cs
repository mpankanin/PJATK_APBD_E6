using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_E6.Contexts;
using PJATK_APBD_E6.DTOs;
using PJATK_APBD_E6.Models;

namespace PJATK_APBD_E6.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PrescriptionController : ControllerBase
{
    private readonly AppDbContext _context;

    public PrescriptionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(AddPrescriptionDTO addPrescriptionDto)
    {
        // check if patient exists
        var patient = await _context.Patients.FindAsync(addPrescriptionDto.PatientDto.IdPatient);
        if (patient == null)
        {
            var Patient = new Patient
            {
                IdPatient = addPrescriptionDto.PatientDto.IdPatient,
                FirstName = addPrescriptionDto.PatientDto.FirstName,
                LastName = addPrescriptionDto.PatientDto.LastName,
                BirthDate = addPrescriptionDto.PatientDto.BirthDate
            };
            await _context.Patients.AddAsync(Patient);
        }
        
        // check if there aren't more than 10 medicaments on the prescription
        if (addPrescriptionDto.MedicamentIds.Count > 10)
        {
            return BadRequest("Cannot add more than 10 medicaments to the prescription.");
        }
        
        // check if medicaments exist
        foreach (var medicamentId in addPrescriptionDto.MedicamentIds)
        {
            var medicament = await _context.Medicaments.FindAsync(medicamentId);
            if (medicament == null)
            {
                return BadRequest("Medicament with id " + medicamentId + " does not exist.");
            }
        }
        
        // check if due date is after date
        if (addPrescriptionDto.DueDate < addPrescriptionDto.Date)
        {
            return BadRequest("Due date cannot be before date.");
        }
        
        // check if doctor exists
        var doctor = await _context.Doctors.FindAsync(addPrescriptionDto.IdDoctor);
        if (doctor == null)
        {
            return BadRequest("Doctor with id " + addPrescriptionDto.IdDoctor + " does not exist.");
        }
        
        // add prescription
        var prescription = new Prescription
        {
            Date = addPrescriptionDto.Date,
            DueDate = addPrescriptionDto.DueDate,
            IdPatient = patient.IdPatient,
            IdDoctor = addPrescriptionDto.IdDoctor
        };
        
        return Ok(prescription);
    }
    
}