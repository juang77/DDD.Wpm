using Wpm.Management.Domain;

namespace Wpm.Management.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_must_be_iqual()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id);
        var pet2 = new Pet(id);

        Assert.True(pet1 == pet2 );
    }
}