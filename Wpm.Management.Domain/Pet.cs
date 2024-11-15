using System.Diagnostics.CodeAnalysis;
using Wpm.Management.Domain.Enums;
using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain;

public class Pet : Entity
{
    public string? Name { get; init; }

    public Age Age { get; init; }

    public string Color { get; init; }

    public Weight Weight { get; private set; }

    public WeightClass WeightClass { get; private set; }

    public SexOfPet SexOfPet { get; init; }

    public BreedId BreedId { get; init; }

    public Pet(Guid id, string name, Age age, string color, SexOfPet sexOfPet, BreedId breedId)
    { 
        Id = id; 
        Name = name; 
        Age = age; 
        Color = color; 
        SexOfPet = sexOfPet;
        BreedId = breedId;
    }

    public void SetWeight(Weight weight, IBreedService breedService)
    { 
        Weight = weight;
        SetWeightClass(breedService);
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Value);

        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desiredBreed.MaleIdealWeight.From, desiredBreed.MaleIdealWeight.To),
            SexOfPet.Female => (desiredBreed.FemaleIdealWeight.From, desiredBreed.FemaleIdealWeight.To),
            _ => throw new NotImplementedException()
        };

        WeightClass = Weight.Value switch
        {
            _ when Weight.Value < from => WeightClass.Underweight,
            _ when Weight.Value > to => WeightClass.Overweight,
            _ => WeightClass.Ideal
        };
    }
}




