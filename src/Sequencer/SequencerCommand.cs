namespace ScorchGore.Sequencer;

public enum SequencerCommands
{
    SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE = 0,
    HELO = 1,
    EHLO = 2,
    I_HAVE_STONE = 3,
    I_HAD_STONE_FIRST = 4,
    I_HAD_STONE = 5,
    I_HAVE_PAPER = 6,
    I_HAD_PAPER_FIRST = 7,
    I_HAD_PAPER = 8,
    I_HAVE_SCISSORS = 9,
    I_HAD_SCISSORS_FIRST = 10,
    I_HAD_SCISSORS = 11,
    I_HAVE_BRONNEN = 12,
    I_HAD_BRONNEN_FIRST = 13,
    I_HAD_BRONNEN = 14,
    CANVAS_THE_CITY_AND_BRUSH_THE_BACKDROP = 42,
    FIRE_IN_THE_HOLE = 69
}

public class SequencerCommand
{
    public SequencerCommands Command;
    public string Arguments = string.Empty;

    public override string ToString()
    {
        return Command switch
        {
            SequencerCommands.EHLO or SequencerCommands.HELO => $"{Command} {Arguments}".TrimEnd(),
            _ => $"{Arguments} {Command}".TrimEnd(),
        };
    }
}
