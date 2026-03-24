namespace cw3APBD.Models;

public abstract class User
{
    public Guid Id { get; } = Guid.NewGuid();
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxRenatalLimit { get; }

    protected User(string fName, string lName)
    {
        FirstName = fName;
        LastName = lName;
    }
}