using Doors.Declarations;

namespace Doors;

public class DoorExperiment
{
    private readonly IRandomizer _randomizer;
    private int _carIndex = -1;
    private int _firstChoiceIndex = -1;

    public DoorExperiment(IRandomizer randomizer)
    {
        _randomizer = randomizer ?? throw new NullReferenceException();
        Shuffle();
    }
    
    public void Shuffle()
    {
        _carIndex = _randomizer.Next(3);
        _firstChoiceIndex = _randomizer.Next(3);
    }

    public bool ChooseAnother()
    {
        if (_carIndex < 0 || _firstChoiceIndex < 0)
            throw new Exception($"{nameof(Shuffle)} and {nameof(ChooseAnother)} has to be called first");
        
        // the first selection was a 'win', so after changing it will become 'loss'
        if (_carIndex == _firstChoiceIndex)
            return false;

        // the host opens the door with a goat, so changing the decision will automatically be a 'win'
        
        return true;
    }

    public bool CheckIfInsist()
    {
        return _carIndex == _firstChoiceIndex;
    }
}