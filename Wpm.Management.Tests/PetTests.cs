using Wpm.Management.Domain;
using Wpm.Management.Domain.DomainServices;
using Wpm.Management.Domain.Enums;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Tests;

public class PetTests
{
    [Fact]
    public void Pet_must_be_iqual()
    {
        var id = Guid.NewGuid();
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet1 = new Pet(id, "Sasha", new Age(11), "Blanco, Negro y Cafe", SexOfPet.Female, breedId);
        var pet2 = new Pet(id, "Trosky", new Age(4), "Negro", SexOfPet.Male, breedId);

        Assert.True(pet1 == pet2 );
    }

    [Fact]
    public void WeightClass_must_be_ideal()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Test", new Age(11), "Color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(6.9m), breedService);
        Assert.True(pet.WeightClass == WeightClass.Ideal);
    }

    [Fact]
    public void WeightClass_must_be_Underweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Test", new Age(11), "Color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(6.3m), breedService);
        Assert.True(pet.WeightClass == WeightClass.Underweight);
    }

    [Fact]
    public void WeightClass_must_be_Overweight()
    {
        var breedService = new FakeBreedService();
        var breedId = new BreedId(breedService.breeds[0].Id, breedService);
        var pet = new Pet(Guid.NewGuid(), "Test", new Age(11), "Color", SexOfPet.Male, breedId);
        pet.SetWeight(new Weight(10.2m), breedService);
        Assert.True(pet.WeightClass == WeightClass.Overweight);
    }
}