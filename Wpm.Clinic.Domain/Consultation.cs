using Wpm.Clinic.Domain.Enums;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> administeredDrugs = new();


    public PatientId PatientId { get; init; }

    public DateTime ConsultationStart { get; init; }

    public DateTime? ConsultationEnd { get; private set; }

    public Text Diagnosis { get; private set; }

    public Text Treatment { get; private set; }

    public Weight CurrentWeight { get; private set; }

    public ConsultationStatus Status { get; private set; }

    public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administeredDrugs;

    public Consultation(PatientId patientId)
    { 
        Id= Guid.NewGuid();
        PatientId= patientId;
        Status = ConsultationStatus.Started;
        ConsultationStart = DateTime.UtcNow;
    }

    public void SetWeight(Weight weight)
    {
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }

    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }

    public void AdministerDrug(DrugId drugId, Dose dose)
    {
        ValidateConsultationStatus();
        var newDrogAdministration = new DrugAdministration(drugId, dose);
        administeredDrugs.Add(newDrogAdministration);
    }

    public void SetTreatment(Text treatment)
    {
        ValidateConsultationStatus();
        Treatment = treatment;
    }

    public void End()
    {
        ValidateConsultationStatus();
        if (Diagnosis == null || Treatment == null || CurrentWeight == null)
        {
            throw new InvalidOperationException("The consultation cannot be terminated. ");
        }
        Status = ConsultationStatus.Finalized;
        ConsultationEnd = DateTime.UtcNow;
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Finalized)
        {
            throw new InvalidOperationException("Consultation is finalized.");
        }
    }

}
