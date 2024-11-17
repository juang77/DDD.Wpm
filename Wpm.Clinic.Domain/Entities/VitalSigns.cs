using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities
{
    public class VitalSigns : Entity
    {
        public DateTime ReadingDateTime { get; init; }

        public decimal Temperature { get; init; }

        public int HeartRate { get; init; }

        public int RespiratoryRate { get; init; }

        public VitalSigns(DateTime readingDateTime, decimal temperature, int heartRate, int respiratoryRate)
        {
            Id = Guid.NewGuid();

            ReadingDateTime = readingDateTime;

            if (temperature < 0)
            {
                throw new ArgumentException("Temperature cannot be negative.");
            }

            if (heartRate < 0)
            {
                throw new ArgumentException("Heart Rate cannot be negative.");
            }

            if (respiratoryRate < 0)
            {
                throw new ArgumentException("Respiratory Rate cannot be negative.");
            }

            Temperature = temperature;
            HeartRate = heartRate;
            RespiratoryRate = respiratoryRate;
        }

        public VitalSigns() 
        {
        
        }

    }
}
