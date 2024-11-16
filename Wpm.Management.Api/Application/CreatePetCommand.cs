using Wpm.Management.Domain.Enums;

namespace Wpm.Management.Api.Application
{
    public record CreatePetCommand(Guid Id, string Name, int Age, string Color, SexOfPet SexOfPet, Guid BreedId)
    {

    }
}
