namespace cw3APBD.Models;

public class Employee : User
{
    public Employee(string fName, string lName) : base(fName, lName)
    { }
    public override int MaxRentalLimit => 5;
}