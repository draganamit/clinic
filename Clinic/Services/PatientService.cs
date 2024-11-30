using AutoMapper;
using Clinic.Data;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long?> AddPatient(AddPatientDto addPatient)
        {
            try
            {
                Patient patient = _mapper.Map<Patient>(addPatient);
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                return patient.Id;
            }
            catch (Exception)
            {
                throw new Exception("Neuspješno dodavanje pacijenta");
            }
        }

        public async Task<List<GetPatientDto>> GetAllPatients()
        {
            List<Patient> patients = await _context.Patients.Include(p => p.Gender).ToListAsync();
            return _mapper.Map<List<GetPatientDto>>(patients);
        }

        public async Task<List<SelectListItem>> GetListPatients()
        {
            return await _context.Patients
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = StringHelper.PatientFullNameWithJMBG(p.FirstName, p.LastName, p.JMBG)
                })
                .ToListAsync();
        }

        public async Task<GetPatientByIdDto> GetPatientById(long patientId)
        {
            Patient patient = await _context.Patients
                                            .Include(p => p.Gender)
                                            .Where(p => p.Id == patientId)
                                            .FirstOrDefaultAsync()
                                            ?? throw new Exception("Pacijent nije pronadjen u sistemu");
            return _mapper.Map<GetPatientByIdDto>(patient);
        }

        public async Task<GetPatientByIdDto> UpdatePatient(AddPatientDto updatePatient)
        {
            Patient patient = await _context.Patients
                                            .Where(p => p.Id == updatePatient.Id)
                                            .FirstOrDefaultAsync()
                                            ?? throw new Exception("Pacijent nije pronadjen u sistemu");

            patient.FirstName = updatePatient.FirstName;
            patient.LastName = updatePatient.LastName;
            patient.PhoneNumber = updatePatient.PhoneNumber;
            patient.Address = updatePatient.Address;
            patient.DateOfBirth = updatePatient.DateOfBirth;
            patient.GenderId = updatePatient.GenderId;
            patient.JMBG = updatePatient.JMBG;

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetPatientByIdDto>(patient);
        }
    }
}