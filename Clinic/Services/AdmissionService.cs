using AutoMapper;
using Clinic.Data;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class AdmissionService : IAdmissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdmissionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long?> AddAdmission(AddAdmissionDto addAdmission)
        {
            try
            {
                Admission admission = _mapper.Map<Admission>(addAdmission);
                _context.Admissions.Add(admission);
                await _context.SaveChangesAsync();
                return admission.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<GetAdmissionDto>> CancelAdmission(long admissionId)
        {
            Admission admission = await _context.Admissions
                                                .Where(d => d.Id == admissionId)
                                                .FirstOrDefaultAsync() ??
                                                throw new Exception("Prijem nije pronadjen");

            admission.IsCancelled = true;
            _context.Admissions.Update(admission);
            await _context.SaveChangesAsync();
            return await GetAllAdmissions();
        }

        public async Task<List<GetAdmissionDto>> DeleteAdmission(long admissionId)
        {
            Admission admission = await _context.Admissions
                                                .Where(d => d.Id == admissionId)
                                                .FirstOrDefaultAsync() ??
                                                throw new Exception("Prijem nije pronadjen");

            _context.Admissions.Remove(admission);
            await _context.SaveChangesAsync();
            return await GetAllAdmissions();
        }

        public async Task<GetAdmissionByIdDto> GetAdmissionById(long admissionId)
        {
            Admission admission = await _context.Admissions
                                                .Include(a => a.Patient)
                                                .Include(a => a.Doctor)
                                                .Where(d => d.Id == admissionId)
                                                .FirstOrDefaultAsync() ??
                                                throw new Exception("Prijem nije pronadjen");

            return _mapper.Map<GetAdmissionByIdDto>(admission);
        }

        public async Task<List<GetAdmissionDto>> GetAllAdmissions()
        {
            List<Admission> admissions = await _context.Admissions
                                                       .Include(a => a.Patient)
                                                       .Include(a => a.Doctor)
                                                       .Where(a => !a.IsCancelled)
                                                       .ToListAsync();
            return _mapper.Map<List<GetAdmissionDto>>(admissions);
        }

        public async Task<GetAdmissionByIdDto> UpdateAdmission(AddAdmissionDto updateAdmission)
        {
            Admission admission = await _context.Admissions
                                                .Include(a => a.Patient)
                                                .Include(a => a.Doctor)
                                                .Where(a => a.Id == updateAdmission.Id)
                                                .FirstOrDefaultAsync() ??
                                                throw new Exception("Prijem nije pronadjen");

            admission.AdmissionDate = updateAdmission.AdmissionDate;
            admission.DoctorId = updateAdmission.DoctorId;
            admission.PatientId = updateAdmission.PatientId;
            admission.IsEmergency = updateAdmission.IsEmergency;

            _context.Admissions.Update(admission);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetAdmissionByIdDto>(admission);
        }
    }
}