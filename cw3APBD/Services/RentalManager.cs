using cw3APBD.Models;

namespace cw3APBD.Services;

public class RentalManager
{
    private readonly List<Equipment> _equipmentList = new();
    private readonly List<User> _users = new();
    private readonly List<Rental> _rentals = new();
    private readonly IPenaltyCalculator _penaltyCalculator;

    public RentalManager(IPenaltyCalculator penaltyCalculator)
    {
        _penaltyCalculator = penaltyCalculator;
    }

    public void AddEquipment(Equipment item)
    {
        _equipmentList.Add(item);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void RentItem(Equipment equipment, User user, int days)
    {
        if (!equipment.IsAvailable)
        {
            throw new InvalidOperationException($"Equipment '{equipment.Name}' already busy.");
        }

        int activeRentalsCount = _rentals.Count(r => r.UserId == user.Id && r.ReturnDate == null);
        if (activeRentalsCount >= user.MaxRentalLimit)
        {
            Console.WriteLine($"!!! LIMIT REACHED for {user.FirstName}: Cannot rent {equipment.Name}. Max limit is {user.MaxRentalLimit}.");
            return;
        }

        equipment.IsAvailable = false;
        Rental rental = new Rental(user.Id, equipment.Id, days);
        _rentals.Add(rental);
        Console.WriteLine($"Success: {equipment.Name} was given to {user.LastName}. Return due to: {rental.DueDate:dd.MM.yyyy}");
    }

    public void ReturnItem(Guid itemId)
    {
        var rental = _rentals.FirstOrDefault(r => r.EquipmentId == itemId && r.ReturnDate == null);

        if (rental == null)
        {
            throw new Exception("Record of active rental is not found");
        }
        var item = _equipmentList.First(e => e.Id == itemId);
        
        rental.ReturnDate = DateTime.Now;
        item.IsAvailable = true;

        // Считаем штраф через наш сервис
        decimal penalty = _penaltyCalculator.Calculate(rental.DueDate, rental.ReturnDate.Value);
        
        Console.WriteLine($"Item {item.Name} returned. Penalty: {penalty:0.00} PLN");
    }
    
    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue()).ToList();
    }
    public List<Rental> GetUserHistory(Guid userId)
    {
        return _rentals.Where(r => r.UserId == userId).ToList();
    }
    public void PrintStatusReport()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("     SYSTEM STATUS REPORT");
        Console.WriteLine("=================================");
    
        Console.WriteLine($"Total Equipment:   {_equipmentList.Count}");
        Console.WriteLine($"Available items:   {_equipmentList.Count(e => e.IsAvailable)}");
        Console.WriteLine($"Currently rented:  {_equipmentList.Count(e => !e.IsAvailable)}");
    
        var overdueRentals = GetOverdueRentals();
        if (overdueRentals.Count > 0)
        {
            Console.WriteLine($"WARNING: {overdueRentals.Count} overdue rental(s) detected!");
        }
        else
        {
            Console.WriteLine("Status: No overdue rentals. Everything is fine.");
        }
    
        Console.WriteLine("=================================\n");
    }
}