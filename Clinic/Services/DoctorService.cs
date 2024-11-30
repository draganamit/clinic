using AutoMapper;
using Clinic.Data;
using Clinic.Enums;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long?> AddDoctor(AddDoctorDto addDoctor)
        {
            try
            {
                Doctor doctor = _mapper.Map<Doctor>(addDoctor);
                var doctorCount = await _context.Doctors.CountAsync();
                doctor.DoctorCode = StringHelper.DoctorCodeGenerator(doctor.FirstName, doctor.LastName, doctorCount);
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return doctor.Id;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<GetDoctorDto>> GetAllDoctors()
        {
            List<Doctor> doctors = await _context.Doctors.Include(d => d.Gender).Include(d => d.Title).ToListAsync();
            return _mapper.Map<List<GetDoctorDto>>(doctors);
        }

        public async Task<GetDoctorByIdDto> GetDoctorById(long doctorId)
        {
            Doctor? doctor = await _context.Doctors
                                          .Include(d => d.Gender)
                                          .Include(d => d.Title)
                                          .Where(d => d.Id == doctorId)
                                          .FirstOrDefaultAsync() ??
                                          throw new Exception("Ljekar nije pronadjen");
            return _mapper.Map<GetDoctorByIdDto>(doctor);
        }

        public async Task<List<SelectListItem>> GetListDoctors()
        {
            return await _context.Doctors
                .Where(d => d.TitleId == (long)TitleEnum.Specialist)
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = StringHelper.PatientFullNameWithJMBG(d.FirstName, d.LastName, d.JMBG)
                })
                .ToListAsync();
        }

        public async Task<GetDoctorByIdDto> UpdateDoctor(AddDoctorDto updateDoctor)
        {
            Doctor doctor = await _context.Doctors
                                          .Include(d => d.Gender)
                                          .Include(d => d.Title)
                                          .Where(d => d.Id == updateDoctor.Id)
                                          .FirstOrDefaultAsync() ??
                                           throw new Exception("Ljekar nije pronadjen");

            doctor.FirstName = updateDoctor.FirstName;
            doctor.LastName = updateDoctor.LastName;
            doctor.PhoneNumber = updateDoctor.PhoneNumber;
            doctor.Address = updateDoctor.Address;
            doctor.DateOfBirth = updateDoctor.DateOfBirth;
            doctor.GenderId = updateDoctor.GenderId;
            doctor.JMBG = updateDoctor.JMBG;
            doctor.TitleId = updateDoctor.TitleId;
            doctor.DoctorCode = StringHelper.DoctorCodeGenerator(updateDoctor.FirstName, updateDoctor.LastName, StringHelper.GetDoctorCodeNumber(doctor.DoctorCode));

            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
            return _mapper.Map<GetDoctorByIdDto>(doctor);
        }
    }
}