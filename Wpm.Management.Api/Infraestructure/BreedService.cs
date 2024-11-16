using Wpm.Management.Domain;
using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infraestructure
{
    public class BreedService : IBreedService
    {
        public readonly List<Breed> breeds =
            [
                new Breed(Guid.Parse("1c10f44e-83b1-4094-b6b1-4298991d9d71"), "ShitZu", new WeightRange(5.5m, 7.5m), new WeightRange(6.5m, 8.5m)),
                new Breed(Guid.Parse("63386cae-79c2-4180-8630-60c6cdf2f5f1"), "German Chepard", new WeightRange(16m, 25m), new WeightRange(20m, 32m))
            ];

        public Breed? GetBreed(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("Breed is not valid");
            }

            var result = breeds.Find(breeds => breeds.Id == id);
            return (result ?? throw new ArgumentException("The breed was not found."));
        }
    }
}
