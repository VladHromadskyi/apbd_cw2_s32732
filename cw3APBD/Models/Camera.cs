namespace cw3APBD.Models;

public class Camera : Equipment
{
    public string Resolution { get; set; }
    public string SensorType { get; set; }
    public Camera(string name, string sn, string resolution, string sensorType) : base(name, sn)
    {
        Resolution = resolution;
        SensorType = sensorType;
    }

    public override string GetSpecifications()
    {
        return $"Resolution: {Resolution}, Sensor: {SensorType}";
    }
}