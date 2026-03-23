namespace apbd_cw2_git_s33470.users;

public abstract class AbstractUser
{
    private static int _IdCounter = 0;
    public int Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public abstract UserType Type { get; }
    public abstract int MaxEquipment { get; }

    protected AbstractUser(string firstName, string lastName)
    {
        Id = GetId();
        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return $"({Id}): {FirstName} {LastName}";
    }
    
    private static int GetId()
    {
        return _IdCounter++;
    }
}