namespace ParkingLot;

public enum VehicleSize { Small, Medium, Large }

public abstract class Vehicle
{
    public Vehicle(string plate)
    {
        Plate = plate;
    }

    public string Plate { get; private set; }
    public abstract VehicleSize Size { get; private set; }
}

public class Motorcycle : Vehicle
{
    public override VehicleSize Size => VehicleSize.Small;

    public Motorcycle(string plate) : base(plate);
}

public class Car : Vehicle
{
    public override VehicleSize Size => VehicleSize.Medium;

    public Car(string plate) : base(plate);
}

public class Truck : Vehicle
{
    public override VehicleSize Size => VehicleSize.Large;

    public Truck(string plate) : base(plate);
}

public class Spot
{
    public VehicleSize Size { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public int Level { get; private set; }

    public void Park(Vehicle vehicle) => Vehicle = vehicle;
    public bool IsFree() => Vehicle == null;
    public bool CanFit(VehicleSize size) => Size >= size;
    public void UnPark() => Vehicle = null;

    public Spot(VehicleSize size, int level)
    {
        Size = size;
        Level = level;
    }
}

public interface IPaymentStrategy
{
    decimal Calculate(Ticket ticket, DateTime leaveTime, decimal price);
}

public class HourlyStrategy : IPaymentStrategy
{
    public decimal Calculate(Ticket ticket, DateTime leaveTime, decimal price)
    {
        return (leaveTime - ticket.enterTime).TotalHours * price;
    }
}

public record Ticket(Vehicle Vehicle, DateTime EnterTime);

public class ParkingLot
{
    private readonly List<Spot> _spots;
    private readonly IPaymentStrategy _paymentStrategy;
    private readonly decimal _price;

    public ParkingLot(List<Spot> spots, IPaymentStrategy paymentStrategy, decimal price)
    {
        _spots = spots;
        _paymentStrategy = paymentStrategy;
        _price = price;
    }

    public Ticket Enter(Vehicle vehicle)
    {
        var spot = _spots.FirstOrDefault(x => x.IsFree() && x.CanFit(vehicle.Size));

        if (spot == null) throw new Exception("There is no spot free for this vehicle size");

        spot.Park(vehicle);

        return new Ticket(vehicle, DateTime.Now);
    }

    public decimal Leave(Ticket ticket)
    {
        var price = _paymentStrategy.Calculate(ticket, DateTime.Now, _price);

        var spot = _spots.FirstOrDefault(x => x.Vehicle != null && x.Vehicle.Plate == ticket.Vehicle.Plate);

        if (spot == null) throw new Exception("There is no spot associated with this vehicle");

        spot.UnPark();

        return price;
    }
}