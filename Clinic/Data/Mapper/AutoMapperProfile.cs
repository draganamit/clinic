using AutoMapper;
using Clinic.Models;
using Clinic.Models.DTOs;

namespace Clinic.Data.Mapper

{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<Patient, AddPatientDto>().ReverseMap();
            CreateMap<Doctor, AddDoctorDto>().ReverseMap();
            CreateMap<Admission, AddAdmissionDto>().ReverseMap();
        }
    }
}
