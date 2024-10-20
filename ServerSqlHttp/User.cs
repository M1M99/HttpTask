public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{Id}. {Name} {LastName}";
    }
}