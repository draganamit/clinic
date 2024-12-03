using AutoMapper;
using Clinic.Helpers;
using Clinic.Models;
using Clinic.Models.Codes;
using Clinic.Models.DTOs;

namespace Clinic.Data.Mapper

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Patient, GetPatientDto>()
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                .ReverseMap();
            CreateMap<Patient, AddPatientDto>().ReverseMap();
            CreateMap<Patient, GetPatientByIdDto>().ReverseMap();
            CreateMap<GetPatientByIdDto, AddPatientDto>().ReverseMap();

            CreateMap<Doctor, GetDoctorDto>()
                .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender.Name))
                .ForMember(dest => dest.TitleName, opt => opt.MapFrom(src => src.Title.Name))
                .ReverseMap();

            CreateMap<Doctor, AddDoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorByIdDto>().ReverseMap();
            CreateMap<GetDoctorByIdDto, AddDoctorDto>().ReverseMap();

            CreateMap<Admission, GetAdmissionDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => $"{src.Doctor.FirstName} {src.Doctor.LastName} - {src.Doctor.DoctorCode}"))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => $"{src.Patient.FirstName} {src.Patient.LastName} ({src.Patient.JMBG})"))
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => src.AdmissionDate.Hour.ToString()))
                .ForMember(dest => dest.Minutes, opt => opt.MapFrom(src => src.AdmissionDate.Minute.ToString()))
                .ForMember(dest => dest.AdmissionDate, opt => opt.MapFrom(src => src.AdmissionDate.ToString("dd.MM.yyyy HH:mm")))
                .ReverseMap()
                .ForMember(dest => dest.AdmissionDate, opt => opt.MapFrom(src => StringHelper.DateTimeFromString(src.AdmissionDate, src.Hours, src.Minutes)));
            
            CreateMap<Admission, AddAdmissionDto>()
                .ForMember(dest => dest.AdmissionDate, opt => opt.MapFrom(src => src.AdmissionDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => src.AdmissionDate.Hour.ToString()))
                .ForMember(dest => dest.Minutes, opt => opt.MapFrom(src => src.AdmissionDate.Minute.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.AdmissionDate, opt => opt.MapFrom(src => StringHelper.DateTimeFromString(src.AdmissionDate.ToString("dd.MM.yyyy"), src.Hours, src.Minutes)));

            CreateMap<Admission, GetAdmissionByIdDto>().ReverseMap();
            CreateMap<GetAdmissionByIdDto, AddAdmissionDto>()
               .ForMember(dest => dest.AdmissionDate, opt => opt.MapFrom(src => src.AdmissionDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => src.AdmissionDate.Hour.ToString()))
                .ForMember(dest => dest.Minutes, opt => opt.MapFrom(src => src.AdmissionDate.Minute.ToString()));

            CreateMap<MedicalReport, MedicalReportDto>()
                .ForMember(dest => dest.Hours, opt => opt.MapFrom(src => src.CreatedAt.Hour))
                .ForMember(dest => dest.Minutes, opt => opt.MapFrom(src => src.CreatedAt.Minute))
                .ReverseMap()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => new DateTime(src.CreatedAt.Year,
                                                                                          src.CreatedAt.Month,
                                                                                          src.CreatedAt.Day,
                                                                                          src.Hours,
                                                                                          src.Minutes,
                                                                                          0)));
        }
    }
}