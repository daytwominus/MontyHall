using Doors;

namespace TestingDoors;

public class Tests
{
    [Test]
    public void Test_10000()
    {
        var doorExperiment = new DoorExperiment(new Randomizer());

        var successCountWhenChangingMind = 0;
        var successCountWhenInsisting = 0;
        var counter = 10000;
        while (counter-- > 0)
        {
            doorExperiment.Shuffle();
            successCountWhenChangingMind += doorExperiment.ChooseAnother() ? 1 : 0;
            successCountWhenInsisting += doorExperiment.CheckIfInsist() ? 1 : 0;
        }
        
        Assert.That(successCountWhenChangingMind is > 6000 and < 7000, Is.True);
        Assert.That(successCountWhenInsisting is > 3000 and < 4000, Is.True);
        Assert.That(successCountWhenChangingMind + successCountWhenInsisting, Is.EqualTo(10000));
    }
}