using AutoMapper;
using MedicaRevolution.Domain.Entities;

namespace MedicaRevolution.Application.Users.Dtos;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<User, PatientForm>()
                .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Diagnosis, opt => opt.Ignore())
                .ForMember(dest => dest.DoctorConclusions, opt => opt.Ignore())
                .ForMember(dest => dest.ResponseDateDoctor, opt => opt.Ignore());

        CreateMap<PatientForm, PatientFormDto>();
    }
}
