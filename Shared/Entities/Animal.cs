namespace Shared.Entities;

public class Animal
{
    public int Id { get; set; }
    public AnimalCategory Category { get; set; }
    public string Name { get; set; }
    public List<AnimalFact> Facts { get; set; }
}