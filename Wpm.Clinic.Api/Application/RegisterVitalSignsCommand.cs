namespace Wpm.Clinic.Api.Application
{
    public record RegisterVitalSignsCommand(Guid ConsultationId, IEnumerable<VitalSignsReading> vitalSignsReadings);
}
