using MediatR;
using MedicaRevolution.Domain.Entities;
using MedicaRevolution.Domain.Exceptions;
using MedicaRevolution.Domain.Interfaces;
using MedicaRevolution.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace MedicaRevolution.Application.Users.Doctors.Commands;

internal class UploadPatientFormCommandHandler(ILogger<UploadPatientFormCommandHandler> logger,
    IDoctorRepository doctorRepository, IBlobStorageService blobStorageService) : IRequestHandler<UploadPatientFormCommand>
{
    public async Task Handle(UploadPatientFormCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Uploading logo for e-mail: {PatientId}", request.Id);
        var patient = await doctorRepository.GetByIdAsync(request.Id);
        if (patient == null) throw new NotFoundException(nameof(PatientForm), request.Id.ToString());
        var logoUrl = await blobStorageService.UploadToBlobAsync(request.File, request.FileName);
        patient.PdfFileName = logoUrl;
        await doctorRepository.SaveChanges();
    }
}
