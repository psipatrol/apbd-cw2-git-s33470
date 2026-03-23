namespace apbd_cw2_git_s33470.equipment.camera;

public class CameraBuilder
{
    private string _name = "Camera";
    private double _value = 0.0;
    private Status _status = Status.Available;
    private string _model = "Undefined";
    private string _sensorType = "Undefined";


    public CameraBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CameraBuilder SetValue(double value)
    {
        _value =  value;
        return this;
    }

    public CameraBuilder SetStatus(Status status)
    {
        _status = status;
        return this;
    }
    
    public CameraBuilder SetModel(string model)
    {
        _model =  model;
        return this;
    }

    public CameraBuilder SetSensorType(string sensorType)
    {
        _sensorType =  sensorType;
        return this;
    }

    public Camera Build()
    {
        Camera camera = new Camera
        (
            _name,
            _value,
            _status,
            _model,
            _sensorType
        );
        
        return camera;
    }
}