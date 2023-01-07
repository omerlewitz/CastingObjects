using BenchmarkDotNet.Attributes;

namespace CastingObjects;


public class Benchmark
{
    [Benchmark()]
    public Person HardCast()
    {
        return (Person)StaticObjects.Omer;
    }
    
    [Benchmark()]
    public Person? SafeCast()
    {
        return StaticObjects.Omer as Person;
    }
    
    [Benchmark()]
    public Person? MatchCast()
    {
        if (StaticObjects.Omer is Person person)
        {
            return person;
        }

        return null;
    }
    
    [Benchmark]
    public List<Person> OfType()
    {
        return StaticObjects.People.OfType<Person>().ToList();
    }
    
    [Benchmark]
    public List<Person> Cast_As()
    {
        return StaticObjects.People.Where(x=> x as Person is not null).Cast<Person>().ToList();
    }
    
    [Benchmark]
    public List<Person> Cast_Is()
    {
        return StaticObjects.People.Where(x=> x is Person).Cast<Person>().ToList();
    }
    
    [Benchmark]
    public List<Person> HardCast_Is()
    {
        return StaticObjects.People
             .Where(x=> x is Person)
             .Select(x=> (Person)x)
             .ToList();
    }
    
    [Benchmark]
    public List<Person> HardCast_As()
    {
        return StaticObjects.People
            .Where(x=> x as Person is not null)
            .Select(x=> (Person)x)
            .ToList();
    }
    
    [Benchmark]
    public List<Person> HardCast_TypeOf()
    {
        return StaticObjects.People
            .Where(x=> x.GetType() == typeof(Person))
            .Select(x=> x)
            .ToList();
    }
}