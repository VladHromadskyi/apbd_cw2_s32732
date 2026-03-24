using cw3APBD.Models;
using cw3APBD.Services;

var calculator = new DailyPenaltyCalculator();
var manager = new RentalManager(calculator);

var student = new Student("Vlad", "Hromadskyi");
var employee = new Employee("Jan", "Kowalski");

var laptop = new Laptop("Dell XPS", "SN-001", "16", 512);
var camera = new Camera("Canon EOS", "SN-C02", "4K", "CMOS");
var projector = new Projector("Epson EB", "SN-P03", "1080p",3000 );

manager.AddUser(student);
manager.AddUser(employee);
manager.AddEquipment(laptop);
manager.AddEquipment(camera);
manager.AddEquipment(projector);

Console.WriteLine("--- Testing Rental System ---\n");

manager.RentItem(laptop, student,7);
manager.RentItem(camera, student,7);

try {
    manager.RentItem(projector, student, 7);
} catch (Exception ex) {
    Console.WriteLine($"Expected Error: {ex.Message}");
}

manager.PrintStatusReport();

manager.ReturnItem(laptop.Id);

Console.WriteLine("\n--- End of Demo ---");