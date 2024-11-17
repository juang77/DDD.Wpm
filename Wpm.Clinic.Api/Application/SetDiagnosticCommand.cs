namespace Wpm.Clinic.Api.Application
{
    public record SetDiagnosticCommand(Guid ConsultationId, string Diagnostic);
}
