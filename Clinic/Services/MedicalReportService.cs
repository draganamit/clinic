using AutoMapper;
using Clinic.Data;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.DTOs;
using Clinic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services
{
    public class MedicalReportService : IMedicalReportService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MedicalReportService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MedicalReportDto> AddMedicalReport(MedicalReportDto addMedicalReport)
        {
            MedicalReport medicalReport = _mapper.Map<MedicalReport>(addMedicalReport);
            _context.MedicalReports.Add(medicalReport);
            await _context.SaveChangesAsync();
            return _mapper.Map<MedicalReportDto>(medicalReport);
        }

        public async Task<long> DeleteMedicalReport(long medicalReportId)
        {
            MedicalReport medicalreport = await _context.MedicalReports
                                                         .Where(mr => mr.Id == medicalReportId)
                                                         .FirstOrDefaultAsync()
                                                         ?? throw new Exception("Nalaz nije pronadjen u sistemu");
            _context.MedicalReports.Remove(medicalreport);
            await _context.SaveChangesAsync();
            return medicalreport.Id;
        }

        public async Task<List<MedicalReportDto>> GetAllMedicalReports()
        {
            List<MedicalReport> medicalReports = await _context.MedicalReports.ToListAsync();
            return _mapper.Map<List<MedicalReportDto>>(medicalReports);
        }

        public async Task<List<MedicalReportDto>> GetAllMedicalReportsForAdmission(long admissionId)
        {
            List<MedicalReport> medicalReports = await _context.MedicalReports.Where(mr => mr.AdmissionId == admissionId).ToListAsync();
            return _mapper.Map<List<MedicalReportDto>>(medicalReports);
        }

        public async Task<MedicalReportDto> GetMedicalReportById(long medicalReportId)
        {
            MedicalReport medicalreport = await _context.MedicalReports
                                                         .Where(mr => mr.Id == medicalReportId)
                                                         .FirstOrDefaultAsync()
                                                         ?? throw new Exception("Nalaz nije pronadjen u sistemu");
            return _mapper.Map<MedicalReportDto>(medicalreport);
        }

        public async Task<MedicalReportDto> UpdateMedicalReport(MedicalReportDto updateMedicalReport)
        {
            MedicalReport medicalReport = await _context.MedicalReports
                                                         .Where(mr => mr.Id == updateMedicalReport.Id)
                                                         .FirstOrDefaultAsync()
                                                         ?? throw new Exception("Nalaz nije pronadjen u sistemu");

            medicalReport.ReportDescription = updateMedicalReport.ReportDescription;
            medicalReport.AdmissionId = updateMedicalReport.AdmissionId;
            medicalReport.CreatedAt = StringHelper.DateTimeFromString(updateMedicalReport.CreatedAt.ToString("dd.MM.yyyy"), updateMedicalReport.Hours, updateMedicalReport.Minutes);

            _context.Update(medicalReport);
            await _context.SaveChangesAsync();

            return _mapper.Map<MedicalReportDto>(medicalReport);
        }
    }
}