public enum Direction { Idle, Up, Down }

public class Elevator
{
    private readonly SortedSet<int> _requests = new();
    public int CurrentFloor { get; private set; }
    public Direction Direction { get; private set; } = Direction.Idle;

    public Elevator(int startFloor) => CurrentFloor = startFloor;

    public void AddRequest(int floor)
    {
        if (floor == CurrentFloor && Direction == Direction.Idle)
        {
            OpenDoors();
            return;
        }

        _requests.Add(floor); // SortedSet ignores duplicates

        if (Direction == Direction.Idle) {
            Direction = floor > CurrentFloor ? Direction.Up : Direction.Down;
        }
    }

    // One tick = move one floor
    public void Step()
    {
        if (Direction == Direction.Idle) return;

        CurrentFloor += Direction == Direction.Up ? 1 : -1;

        if (_requests.Remove(CurrentFloor))
            OpenDoors();

        UpdateDirection();
    }

    private void UpdateDirection()
    {
        if (_requests.Count == 0)
        {
            Direction = Direction.Idle;
            return;
        }

        var hasAbove = _requests.Max > CurrentFloor;
        var hasBelow = _requests.Min < CurrentFloor;

        if (Direction == Direction.Up && !hasAbove) Direction = Direction.Down;
        else if (Direction == Direction.Down && !hasBelow) Direction = Direction.Up;
    }

    private void OpenDoors() => Console.WriteLine($"Doors open at floor {CurrentFloor}");
}

public class Building
{
    private readonly Elevator _elevator;
    private readonly int _floors;

    public Building(Elevator elevator, int floors) => (_elevator, _floors) = (elevator, floors);

    public void CallElevator(int floor) => _elevator.AddRequest(Validate(floor));
    public void SelectFloor(int floor) => _elevator.AddRequest(Validate(floor));

    private int Validate(int floor) =>
        floor >= 0 && floor < _floors
            ? floor
            : throw new ArgumentOutOfRangeException(nameof(floor));
}