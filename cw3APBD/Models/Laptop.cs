namespace cw3APBD.Models;

public class Laptop : Equipment
{
    public string Processor { get; set; }
    public int RamGb { get; set; }
    public Laptop(string name, string sn, string cpu, int ram) : base(name, sn)
    {
        Processor = cpu;
        RamGb = ram;
    }

    public override string GetSpecifications()
    {
        return $"CPU: {Processor}, RAM: {RamGb}GB";
    }
}