namespace Wpm.Clinic.Api.Application
{
    public record SetTreatmentCommand(Guid ConsultationId, string Tratement);
}
