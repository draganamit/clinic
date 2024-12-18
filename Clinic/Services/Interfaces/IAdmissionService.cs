﻿using Clinic.Models.DTOs;

namespace Clinic.Services.Interfaces
{
    public interface IAdmissionService
    {
        Task<GetAdmissionByIdDto> GetAdmissionById(long admissionId);

        Task<GetAdmissionDto> GetAdmissionDetailsById(long admissionId);

        Task<List<GetAdmissionDto>> GetAllAdmissions();

        Task<long?> AddAdmission(AddAdmissionDto addAdmission);

        Task<GetAdmissionByIdDto> UpdateAdmission(AddAdmissionDto updateAdmission);

        Task<List<GetAdmissionDto>> DeleteAdmission(long admissionId);

        Task<List<GetAdmissionDto>> CancelAdmission(long admissionId);

        Task<List<GetAdmissionDto>> SearchAdmissions(DateTime? startDate, DateTime? endDate, int? statusId);
    }
}