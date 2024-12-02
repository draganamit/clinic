using Clinic.Models.DTOs;

namespace Clinic.Services.Interfaces
{
    public interface IMedicalReportService
    {
        Task<MedicalReportDto> GetMedicalReportById(long medicalReportId);

        Task<List<MedicalReportDto>> GetAllMedicalReports();

        Task<List<MedicalReportDto>> GetAllMedicalReportsForAdmission(long admissionId);

        Task<MedicalReportDto> AddMedicalReport(MedicalReportDto addMedicalReport);

        Task<MedicalReportDto> UpdateMedicalReport(MedicalReportDto updateMedicalReport);

        Task<long> DeleteMedicalReport(long medicalReportId);
    }
}