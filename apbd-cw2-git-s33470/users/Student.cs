namespace apbd_cw2_git_s33470.users;

public class Student : AbstractUser
{
    public string StudentIndex { get; init; }
    public override int MaxEquipment => 2;
    public override UserType Type => UserType.Student;

    public Student(
        string firstName,
        string lastName,
        string index
    ) : base(firstName, lastName)
    {
        StudentIndex = index;
    }
    
}