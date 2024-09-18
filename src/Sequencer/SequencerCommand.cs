namespace ScorchGore.Sequencer;

public enum SequencerCommands
{
    INDETERMINATE = 0,
    SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE = 1,
    HELO = 2,
    OHAI = 3,
    I_HAVE_STONE = 4,
    I_HAD_STONE_FIRST = 5,
    I_HAD_STONE = 6,
    I_HAVE_PAPER = 7,
    I_HAD_PAPER_FIRST = 8,
    I_HAD_PAPER = 9,
    I_HAVE_SCISSORS = 10,
    I_HAD_SCISSORS_FIRST = 11,
    I_HAD_SCISSORS = 12,
    I_HAVE_BRONNEN = 13,
    I_HAD_BRONNEN_FIRST = 14,
    I_HAD_BRONNEN = 15,
    CANVAS_THE_CITY_AND_BRUSH_THE_BACKDROP = 42,
    INITIATORS_TURN = 43,
    TURN_OF_HE_WHOMST_JOINED = 44,
    GONNA_WRITE_YOU_A_WHOLE_ASS_OPERATING_SYSTEM_FOR_THAT_TRICKSHOT = 45,
    FIRE_IN_THE_HOLE = 69,
    KTHXBYE = 111
}

public class SequencerCommand
{
    public SequencerCommands Command;
    public string Arguments = string.Empty;

    public override string ToString()
    {
        return Command switch
        {
            SequencerCommands.OHAI or SequencerCommands.HELO => $"{Command} {Arguments}".TrimEnd(),
            _ => $"{Arguments} {Command}".TrimStart(),
        };
    }

    public static SequencerCommand FromLine(string line)
    {
        SequencerCommands command;
        var args = string.Empty;

        if (line.StartsWith(SequencerCommands.HELO.ToString()))
        {
            command = SequencerCommands.HELO;
            args = line.Substring(SequencerCommands.HELO.ToString().Length).TrimStart();
        }
        else if (line.StartsWith(SequencerCommands.OHAI.ToString()))
        {
            command = SequencerCommands.OHAI;
            args = line.Substring(SequencerCommands.OHAI.ToString().Length).TrimStart();
        }
        else
        {
            var parts = line.Split(' ').ToList();

            if (!Enum.TryParse(parts.Last(), out command))
            {
                throw new ArgumentOutOfRangeException(nameof(line), line, $"Unknown command {parts[0]}");
            }

            if (parts.Count > 1)
            {
                parts.RemoveAt(parts.Count - 1);
                args = string.Join(' ', parts);
            }
        }

        return new SequencerCommand
        {
            Command = command,
            Arguments = args
        };
    }
}
