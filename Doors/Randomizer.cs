using Doors.Declarations;

namespace Doors;

public class Randomizer : IRandomizer
{
    private static readonly Random Random = new();
    public int Next(int max)
    {
        return Random.Next(max);
    }
}