namespace Wpm.Clinic.Api.Application
{
    public record VitalSignsReading(DateTime ReadingDateTime, decimal Temperatuire, int HeartRate, int RespiratoryRate);
}
