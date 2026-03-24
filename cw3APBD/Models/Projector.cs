namespace cw3APBD.Models;

public class Projector : Equipment
{
    public string Resolution { get; set; }
    public int Brightness { get; set; }
    public Projector(string name, string sn, string resolution, int brightness) : base(name, sn)
    {
        Resolution = resolution;
        Brightness = brightness;
    }

    public override string GetSpecifications()
    {
        return $"Resolution: {Resolution}, Brightness: {Brightness}";
    }
}