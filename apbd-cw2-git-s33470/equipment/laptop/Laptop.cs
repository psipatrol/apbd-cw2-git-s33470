namespace apbd_cw2_git_s33470.equipment.laptop;

public class Laptop : AbstractEquipment
{
    public string Model {get; init;}
    public string Gpu {get; init;}
    public string Cpu {get; init;}
    public int RamGb {get; init;}

    public Laptop(
        string name, 
        double value, 
        Status status,
        string model,
        string gpu,
        string cpu,
        int ramGb
    ) : base(name, value, status)
    {
        Model = model;
        Gpu = gpu;
        Cpu = cpu;
        RamGb = ramGb;
    }
}