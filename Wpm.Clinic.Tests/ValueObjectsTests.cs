using Wpm.Clinic.Domain.ValueObjects;
using Wpm.Clinic.Domain.Enums;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Tests
{
    public class ValueObjectsTests
    {
        [Fact]
        public void Dose_must_be_iqual()
        {
            var dose1 = new Dose(20.5m, UnitOfMeasure.ml);
            var dose2 = new Dose(20.5m, UnitOfMeasure.ml);
            Assert.Equal(dose1, dose2);
        }
    }
}
