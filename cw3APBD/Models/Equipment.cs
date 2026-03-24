namespace cw3APBD.Models;

public abstract class Equipment
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; set; }
    public bool IsAvailable { get; set; } = true;
    public string SerialNumber { get; set; }

    protected Equipment(string name, string serialNumber)
    {
        Name = name;
        SerialNumber = serialNumber;
    }

    public abstract string GetSpecifications();
}