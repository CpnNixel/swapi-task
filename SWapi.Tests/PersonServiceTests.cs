using MockQueryable.Moq;
using Moq;
using SWapi.Data;
using SWapi.Data.Models;
using SWapi.Services;
using SWapi.Services.Interfaces;

namespace SWapi.Tests;

public class PersonServiceTests
{
    private Mock<StarWarsDbContext> personContextMock;
    private IPersonService service;
    private const string personName = "Han Solo";

    public PersonServiceTests()
    {
        var expectedPerson = ExpectedPerson();

        var mock = new List<Person> { expectedPerson }
            .BuildMock()
            .BuildMockDbSet();

        personContextMock = new Mock<StarWarsDbContext>();
        personContextMock.Setup(x => x.People).Returns(mock.Object);

        service = new PersonService(personContextMock.Object);
    }

    [Fact]
    public async Task GetByName_ShouldReturnPerson()
    {
        var people = await service.GetByName(personName);

        Assert.NotNull(people);
        Assert.Single(people);
        Assert.True(people.First().Name == personName);
    }

    [Fact]
    public async Task GetByName_ShouldReturnEmpty()
    {
        var people = await service.GetByName("testname");

        Assert.Empty(people);
    }

    private static Person ExpectedPerson() =>
        new()
        {
            Id = 111,
            Name = personName,
            BirthYear = "29 BBY",
            EyeColor = "Brown",
            Gender = "Male",
            HairColor = "Brown",
            Height = "180",
            Mass = "80",
            SkinColor = "Light",
            HomeWorld = new Planet { Name = "Corellia" }
        };
}
