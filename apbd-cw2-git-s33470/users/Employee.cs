namespace apbd_cw2_git_s33470.users;

public class Employee : AbstractUser
{
    public string Department { get; init; }
    public override int MaxEquipment => 5;
    public override UserType Type => UserType.Employee;
    
    public Employee(
        string firstName, 
        string lastName,
        string department
        ) : base(firstName, lastName)
    {
        Department = department;
    }
}