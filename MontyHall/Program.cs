using CommandLine;
using Doors;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions);
return;

static void RunOptions(Options opts)
{
    var doorExperiment = new DoorExperiment(new Randomizer());

    var winCounter = 0;
    
    var count = opts.Amount;
    while (count-- > 0)
    {
        doorExperiment.Shuffle();
        if (opts.Change)
            winCounter += doorExperiment.ChooseAnother() ? 1 : 0;
        else 
            winCounter += doorExperiment.CheckIfInsist() ? 1 : 0;
    }
    
    Console.WriteLine($"After running experiment {opts.Amount} times and {(opts.Change ? "with":"without")} changing decision"+
                      $" user won in {winCounter} times");
}

public class Options
{
    [Option('a', "amount", Required = true, HelpText = "Amount of attempts")]
    public uint Amount { get; set; }
    
    [Option('c', "change", Required = false, HelpText = "use it if an another door has to be selected")]
    public bool Change { get; set; }
}

