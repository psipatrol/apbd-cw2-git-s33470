namespace apbd_cw2_git_s33470.equipment;

public abstract class AbstractEquipment
{
    private static int _IdCounter = 0;
    public int Id { get; init; }
    public string Name { get; init; }
    public double Value { get; init;  }
    public Status Status {get; private set;}

    
    public AbstractEquipment(string name,  double value, Status status)
    { 
        Id = GetId();
        Name = name; 
        Value = value;
        Status = status;
    }

    private static int GetId()
    {
        return _IdCounter++;
    }
    
    public void MarkAsAvailable()
    {
        Status = Status.Available;
    }

    public void MarkAsRented()
    {
        Status = Status.Rented;
    }

    public void MarkAsInService()
    {
        Status = Status.InService;
    }

    public void MarkAsDamaged()
    {
        Status = Status.Damaged;
    }

    public override string ToString()
    {
        return $"({Id}) {Name}, {Value}, {Status}";
    }
    
}