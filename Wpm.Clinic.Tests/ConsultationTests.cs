using Wpm.Clinic.Domain;
using Wpm.Clinic.Domain.Enums;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Tests;

public class ConsultationTests
{
    [Fact]
    public void Consultation_must_be_started()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.True(c.Status == ConsultationStatus.Started);

    }

    [Fact]
    public void Consultation_should_not_have_an_end_date()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Null(c.ConsultationEnd);
    }

    [Fact]
    public void Consultation_should_not_finalice_if_data_is_missing()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(c.End);
    }

    [Fact]
    public void Consultation_should_finalice_with_completed_data()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tratement");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.True(c.Status == ConsultationStatus.Finalized);
    }

    [Fact]
    public void Consultation_cannot_allow_to_change_weight_when_it_is_finalized()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tratement");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetWeight(19.2m));
    }

    [Fact]
    public void Consultation_cannot_allow_to_change_diagnostic_when_it_is_finalized()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tratement");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetDiagnosis("New Diagnostic"));
    }

    [Fact]
    public void Consultation_cannot_allow_to_change_tratement_when_it_is_finalized()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Tratement");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetTreatment("New Tratement"));
    }

    [Fact]
    public void Consultation_add_medicine()
    {
        var drugId = new DrugId(Guid.NewGuid());
        var c = new Consultation(Guid.NewGuid());
        c.AdministerDrug(drugId, new Dose(1, UnitOfMeasure.tablet));
        Assert.True(c.AdministeredDrugs.Count == 1);
        Assert.True(c.AdministeredDrugs.First().DrugId == drugId);
    }

    [Fact]
    public void Consultation_add_Vital_Signs()
    {
        var c = new Consultation(Guid.NewGuid());
        IEnumerable<VitalSigns> vitalSigns = [new VitalSigns(38.8m, 100, 120)];
        c.RegisterVitalSigns(vitalSigns);
        Assert.True(c.VitalSignsReadings.Count == 1);
        Assert.True(c.VitalSignsReadings.First() == vitalSigns.First());
    }
}