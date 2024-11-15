namespace Wpm.Clinic.Domain.ValueObjects
{
    public record Text
    {
        public string Value { get; init; }

        public Text(string value)
        { 

            Value = value;
        }

        private void Vaidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            { 
                throw new ArgumentNullException("value", "Text is not valid.");
            }

            if (value.Length > 500)
            {
                throw new ArgumentNullException("Text is too Long.");
            }
        }

        public static implicit operator Text(string value)
        {
            return new Text(value);
        }
    }
}
