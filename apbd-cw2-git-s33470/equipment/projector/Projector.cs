namespace apbd_cw2_git_s33470.equipment.projector;

public class Projector : AbstractEquipment
{
    public string Model {get; init;}
    public int Lumens {get; init;}
    
    public Projector(
        string name, 
        double value, 
        Status status,
        string model,
        int lumens
    ) : base(name, value, status)
    {
        Model = model;
        Lumens = lumens;
    }
}