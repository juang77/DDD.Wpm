using Wpm.Clinic.Domain.Enums;

namespace Wpm.Clinic.Api.Application
{
    public record AdministerDrugsCommand(Guid ConsultationId, Guid DrugId, decimal Quantity, UnitOfMeasure unitOfMeasure);
}
