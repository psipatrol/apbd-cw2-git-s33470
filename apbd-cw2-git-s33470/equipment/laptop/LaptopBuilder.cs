namespace apbd_cw2_git_s33470.equipment.laptop;

public class LaptopBuilder
{
    private string _name = "laptop";
    private double _value = 0;
    private Status _status = Status.Available;
    private string _model = "Undefined";
    private string _gpu = "Undefined";
    private string _cpu = "Undefined";
    private int _ramGb = 0;


    public LaptopBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public LaptopBuilder SetValue(double value)
    {
        _value =  value;
        return this;
    }

    public LaptopBuilder SetStatus(Status status)
    {
        _status = status;
        return this;
    }
    
    public LaptopBuilder SetModel(string model)
    {
        _model =  model;
        return this;
    }

    public LaptopBuilder SetGpu(string gpu)
    {
        _gpu =  gpu;
        return this;
    }

    public LaptopBuilder SetCpu(string cpu)
    {
        _cpu =  cpu;
        return this;
    }

    public LaptopBuilder SetRamGb(int ramGb)
    {
        _ramGb = ramGb;
        return this;
    }

    public Laptop Build()
    {
        Laptop laptop = new Laptop
        (
            _name,
            _value,
            _status,
            _model,
            _gpu,
            _cpu,
            _ramGb
        );
        
        return laptop;
    }
    
}