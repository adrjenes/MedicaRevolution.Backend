using AutoMapper;
using MediatR;
using MedicaRevolution.Application.Users.Doctors.Queries;
using MedicaRevolution.Application.Users.Dtos;
using MedicaRevolution.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace MedicaRevolution.Application.Users.Patients.Queries.GetMyForms;

public class GetMyFormsQuery : IRequest<List<PatientFormDto>>
{
    
}
