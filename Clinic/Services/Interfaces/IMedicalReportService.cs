using Clinic.Models.DTOs;

namespace Clinic.Services.Interfaces
{
    public interface IMedicalReportService
    {
        Task<MedicallReportDto> GetMedicalReportById(long medicalReportId);

        Task<List<MedicallReportDto>> GetAllMedicalReports();

        Task<MedicallReportDto> AddMedicalReport(MedicallReportDto addMedicalReport);

        Task<MedicallReportDto> UpdateMedicalReport(MedicallReportDto updateMedicalReport);

        Task<long> DeleteMedicalReport(long medicalReportId);
    }
}