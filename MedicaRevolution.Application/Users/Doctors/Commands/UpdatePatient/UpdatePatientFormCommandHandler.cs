using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Exceptions;
using MedicaRevolution.Domain.Repositories;
using MedicaRevolution.Domain.Interfaces;

namespace MedicaRevolution.Application.Users.Doctors.Commands.UpdatePatient;

public class UpdatePatientFormCommandHandler(ILogger<UpdatePatientFormCommandHandler> logger, IDoctorRepository doctorRepository, 
    IMapper mapper, IBlobStorageService blobStorageService) : IRequestHandler<UpdatePatientFormCommand>
{
    public async Task Handle(UpdatePatientFormCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating and uploading patient form with id: {PatientFormId}", request.Id);
        var patientForm = await doctorRepository.GetByIdAsync(request.Id);
        if (patientForm == null) throw new NotFoundException(nameof(PatientForm), request.Id.ToString());
      
        if (!string.IsNullOrEmpty(request.Description)) patientForm.Description = request.Description;
        if (!string.IsNullOrEmpty(request.Diagnosis)) patientForm.Diagnosis = request.Diagnosis;
        if (!string.IsNullOrEmpty(request.DoctorConclusions)) patientForm.DoctorConclusions = request.DoctorConclusions;
        patientForm.StartDate = request.startDate;
        patientForm.EndDate = request.endDate;
        patientForm.ResponseDateDoctor = DateTime.UtcNow;
        patientForm.isArchive = request.isArchive;
        if (request.File != null)
        {
            var logoUrl = await blobStorageService.UploadToBlobAsync(request.File.OpenReadStream(), request.File.FileName);
            patientForm.PdfFileName = logoUrl;
        }
        await doctorRepository.SaveChanges();
    }
}