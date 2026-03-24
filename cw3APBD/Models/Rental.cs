namespace cw3APBD.Models;

public class Rental
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; }
    public Guid EquipmentId { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; set; }

    public Rental(Guid userId, Guid equipmentId, int durationDays)
    {
        UserId = userId;
        EquipmentId = equipmentId;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(durationDays);
    }

    public bool IsOverdue()
    {
        return !ReturnDate.HasValue && (DateTime.Now > DueDate);
    }
}