using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infraestructure
{
    public class BreedService : IBreedService
    {
        public readonly List<Breed> breeds =
            [
                new Breed(Guid.Parse("1c10f44e-83b1-4094-b6b1-4298991d9d71"), "ShitZu", new WeightRange(6.5m, 9.5m), new WeightRange(5.5m, 7.5m)),
                new Breed(Guid.Parse("63386cae-79c2-4180-8630-60c6cdf2f5f1"), "German Chepard", new WeightRange(25.5m, 40.5m), new WeightRange(27.5m, 45.5m))
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
