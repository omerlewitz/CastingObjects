namespace CastingObjects;

public class StaticObjects
{
    public static object Omer = new Person()
    {
        Id = Guid.NewGuid(),
        Name = "Omer"
    };

    public static List<Person> People = Enumerable
        .Range(0, 1000)
        .Select(person => new Person
        {
            Id = Guid.NewGuid(),
            Name = Guid.NewGuid().ToString()
        }).ToList();

}