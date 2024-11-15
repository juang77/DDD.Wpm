using Wpm.Clinic.Domain.Enums;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record Dose
    {
        public decimal Quantity { get; init; }

        public UnitOfMeasure Unit { get; set; }

        public Dose(decimal quatity, UnitOfMeasure unit)
        { 
            Quantity = quatity;
            Unit = unit;
        }
    }
}
