namespace Wpm.Clinic.Api.Application
{
    public record SetWeightCommand(Guid ConsultationId, decimal Weight);
}
