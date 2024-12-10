using System.Security.Cryptography.X509Certificates;

namespace Wpm.Management.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Pet_should_be_equal()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Gofret",8, "yelow", new Weight(20.5m),SexOfPet.Female);
        var pet2 = new Pet(id, "Bal", 13, "brown", new Weight(30.5m), SexOfPet.Male);

        Assert.True(pet1.Equals(pet2));
    }
    [Fact]
    public void Pet_should_be_equal_using_operators()
    {
        var id = Guid.NewGuid();
        var pet1 = new Pet(id, "Gofret", 8, "yelow", new Weight(20.5m), SexOfPet.Female);
        var pet2 = new Pet(id, "Bal", 13, "brown", new Weight(30.5m), SexOfPet.Male);

        Assert.True(pet1==pet2);
    }
    [Fact]
    public void Pet_should_not_be_equal_using_operators()
    {
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        var pet1 = new Pet(id1, "Gofret", 8, "yelow", new Weight(20.5m), SexOfPet.Female);
        var pet2 = new Pet(id2, "Bal", 13, "brown", new Weight(30.5m), SexOfPet.Male);
        Assert.True(pet1 != pet2);
    }
    [Fact]
    public void Weight_should_be_equal()
    {
        var w1 = new Weight(20.5m);
        var w2 = new Weight(20.5m);

        Assert.True(w1 == w2);
    }
}
