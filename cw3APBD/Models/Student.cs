namespace cw3APBD.Models;

public class Student : User
{
    public Student(string fName, string lName) : base(fName, lName)
    { }

    public override int MaxRentalLimit => 2;
}