using Wpm.Management.Domain.DomainServices;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Tests
{
    public class ValueObjectsTests
    {
        [Fact]
        public void Weight_must_be_iqual()
        {
            var weight1 = new Weight(20.5m);
            var weight2 = new Weight(20.5m);
            Assert.Equal(weight1, weight2);
        }

        [Fact]
        public void Range_weight_must_be_iqual()
        {
            var wr1 = new WeightRange(10.5m, 20.5m);
            var wr2 = new WeightRange(10.5m, 20.5m);
            Assert.Equal(wr1, wr2);
        }

        [Fact]
        public void Breed_id_must_be_valid()
        {
            var breedService = new FakeBreedService();
            var id = breedService.breeds[0].Id;
            var breedId = new BreedId(id, breedService);
            Assert.NotNull(breedId);
        }

        [Fact]
        public void Breed_id_must_be_not_valid()
        {
            var breedService = new FakeBreedService();
            var id = Guid.NewGuid();
            Assert.Throws<ArgumentException>(() => {
                var breedId = new BreedId(id, breedService);
            });
            
        }
    }
}
