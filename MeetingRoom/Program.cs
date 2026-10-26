public class Booking
{
    public Employee Employee { get; }
    public Room Room { get; }
    public int Attendees { get; }
    public DateTime Start { get; }
    public DateTime End { get; }

    public Booking(Employee employee, Room room, int attendees, DateTime start, DateTime end)
        => (Employee, Room, Attendees, Start, End) = (employee, room, attendees, start, end);

    public bool Overlaps(DateTime start, DateTime end) => start < End && Start < end;
    public bool HasEnded(DateTime now) => End <= now;
}

public class Room
{
    private readonly List<Booking> _bookings = new();
    public string Name { get; }
    public int Capacity { get; }

    public Room(string name, int capacity) => (Name, Capacity) = (name, capacity);

    public bool IsFree(DateTime start, DateTime end) => !_bookings.Any(b => b.Overlaps(start, end));

    public void Add(Booking booking)
    {
        if (!IsFree(booking.Start, booking.End))
            throw new InvalidOperationException("Room already booked");
        _bookings.Add(booking);
    }

    public bool Remove(Booking booking) => _bookings.Remove(booking);
}

public record BookingResult(bool Success, string Message, Booking? Booking);

public class Office
{
    private readonly List<Room> _rooms;
    private readonly object _lock = new();

    public Office(List<Room> rooms) => _rooms = rooms;

    public BookingResult Book(Employee employee, DateTime start, DateTime end, int attendees)
    {
        if (end <= start) return new(false, "End must be after start", null);
        if (attendees <= 0) return new(false, "Attendees must be positive", null);

        lock (_lock)
        {
            var room = _rooms
                .Where(r => r.Capacity >= attendees && r.IsFree(start, end))
                .OrderBy(r => r.Capacity)
                .FirstOrDefault();

            if (room == null) return new(false, "No room available", null);

            var booking = new Booking(employee, room, attendees, start, end);
            room.Add(booking);
            return new(true, string.Empty, booking);
        }
    }

    public BookingResult Cancel(Employee employee, Booking booking)
    {
        if (booking.Employee.Id != employee.Id) return new(false, "Not the booking owner", null);
        if (booking.HasEnded(DateTime.UtcNow)) return new(false, "Booking already ended", null);

        lock (_lock)
        {
            if (!booking.Room.Remove(booking)) return new(false, "Booking not found", null);
        }

        return new(true, string.Empty, booking);
    }
}