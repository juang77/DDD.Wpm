using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.DomainServices
{
    public class FakeBreedService : IBreedService
    {
        public readonly List<Breed> breeds =
            [
                new Breed (Guid.NewGuid(), "ShitZu", new WeightRange(6.5m, 9.5m), new WeightRange(5.5m, 7.5m)),
                new Breed (Guid.NewGuid(), "German Shepard", new WeightRange(5.5m, 9.5m), new WeightRange(27.5m, 45.5m))
            ];

        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            { 
                throw new ArgumentNullException ("Breed is not valid");
            }

            var result = breeds.Find(breeds => breeds.Id == id);
            return (result ?? throw new ArgumentException("The breed was not found."));
        }
    }
}
