using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record VitalSigns
    {
        public DateTime ReadingDateTime { get; init; }

        public decimal Temperature { get; init; }

        public int HeartRate { get; init; }

        public int RespiratoryRate { get; init; }

        public VitalSigns(decimal temperature, int heartRate, int respiratoryRate)
        {
            ReadingDateTime = DateTime.UtcNow;

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



    }
}
