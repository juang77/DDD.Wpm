namespace Wpm.Clinic.Domain.Interfaces
{
    public interface IDrugService
    {
        Drug? GetDrug(Guid id);
    }
}
