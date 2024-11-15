﻿namespace Wpm.Clinic.Domain.ValueObjects
{
    public record PatientId
    {
        public Guid Value { get; init; }

        public PatientId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new ArgumentException("value", "The ID cannot be null or empty.");
            }
            Value = value;
        }

        public static implicit operator PatientId(Guid value)
        {
            return new PatientId(value);
        }
    }
}
