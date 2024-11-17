using Wpm.Clinic.Api.Infraestructure;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Api.Application
{
    public class ClinicAplicationService(ClinicDbContext dbContext)
    {
        public async Task<Guid> Handle(StartConsultationCommand command)
        {
            var newConsultation = new Consultation(command.PatientId);
            await dbContext.Consultation.AddAsync(newConsultation);
            await dbContext.SaveChangesAsync();
            return newConsultation.Id;
        }

        public async Task Handle(FinalizeConsultationCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.End();
            await dbContext.SaveChangesAsync();
        }

        public async Task Handle(SetDiagnosticCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.SetDiagnosis(command.Diagnostic);
            await dbContext.SaveChangesAsync();
        }

        public async Task Handle(SetTreatmentCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.SetTreatment(command.Tratement);
            await dbContext.SaveChangesAsync();
        }

        public async Task Handle(SetWeightCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.SetWeight(command.Weight);
            await dbContext.SaveChangesAsync();
        }

        public async Task Handle(AdministerDrugsCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.AdministerDrug(command.DrugId, 
                        new Dose(command.Quantity, command.unitOfMeasure));
            await dbContext.SaveChangesAsync();
        }

        public async Task Handle(RegisterVitalSignsCommand command)
        {
            var consultation = await dbContext.Consultation.FindAsync(command.ConsultationId);
            consultation.RegisterVitalSigns(command.vitalSignsReadings.Select(v => new VitalSigns(v.ReadingDateTime, v.Temperatuire, v.HeartRate, v.RespiratoryRate)));
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Consultation>> Handle(PatientConsutationsReadingCommand command)
        {
            var historyConsultations = dbContext.Consultation.Where(c => c.PatientId == command.PatientId).ToList();
            return historyConsultations;
        }
    }
}
