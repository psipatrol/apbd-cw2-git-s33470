namespace apbd_cw2_git_s33470.equipment.projector;

public class ProjectorBuilder
{
    private string _name = "Camera";
    private double _value = 0.0;
    private Status _status = Status.Available;
    private string _model = "Undefined";
    private int _lumens = 0;

    public ProjectorBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public ProjectorBuilder SetValue(double value)
    {
        _value =  value;
        return this;
    }

    public ProjectorBuilder SetStatus(Status status)
    {
        _status = status;
        return this;
    }
    
    public ProjectorBuilder SetModel(string model)
    {
        _model =  model;
        return this;
    }
    
    public ProjectorBuilder SetLumens(int lumens)
    {
        _lumens =  lumens;
        return this;
    }


    public Projector Build()
    {
        Projector projector = new Projector
        (
            _name,
            _value,
            _status,
            _model,
            _lumens
        );
        
        return projector;
    }
}