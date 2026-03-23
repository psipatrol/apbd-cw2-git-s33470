namespace apbd_cw2_git_s33470.equipment.camera;

public class Camera : AbstractEquipment
{
    public string Model {get; init;}
    public string SensorType {get; init;}
    
    public Camera(
        string name, 
        double value, 
        Status status,
        string model,
        string sensorType
        ) : base(name, value, status)
    {
        Model = model;
        SensorType = sensorType;
    }
}