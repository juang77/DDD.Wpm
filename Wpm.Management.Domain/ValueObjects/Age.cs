namespace Wpm.Management.Domain.ValueObjects
{
    public record Age
    {
        public int Value { get; init; }

        public Age(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Age cannot be negative.");
            }

            Value = Value;
        }
    }
}
