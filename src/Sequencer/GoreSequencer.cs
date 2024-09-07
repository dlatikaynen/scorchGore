using ScorchGore.Configuration;
using ScorchGore.GameSession;

namespace ScorchGore.Sequencer;

public class GoreSequencer(GoreSession session, bool isLocal)
{
    public GoreSession Session => session;
    public bool IsLocal => isLocal;

    public Queue<SequencerCommand> CommandQueue = new();

    public bool MyTurnPushCommand(SequencerCommand command)
    {
        if (session.AmITheInitiatorEven && session.Watermark == 0)
        {
            if(command.Command != SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE)
            {
                throw new ArgumentOutOfRangeException(nameof(command.Command), command.Command, $"First turn can only be {SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE}");
            }

            /* new game starts, we write the file for the first time */
            return AppendCommandToGameFile(command, false);
        }

        if(session.AmITheInitiatorEven && int.IsEvenInteger(session.Watermark))
        {
            throw new ArgumentOutOfRangeException(nameof(session.Watermark), session.Watermark, nameof(session.AmITheInitiatorEven));
        }
        else if(session.AmIThePeerOdd && int.IsOddInteger(session.Watermark))
        {
            throw new ArgumentOutOfRangeException(nameof(session.Watermark), session.Watermark, nameof(session.AmIThePeerOdd));
        }

        if (PushNewTurnFile(Session.Watermark + 1, command))
        {
            ++session.Watermark;

            return true;
        }

        return false;
    }

    /// <summary>
    /// Reads into the command queue as long as there are commands
    /// that the querying party has not seen yet, and then adjusts
    /// the watermark for the next turn
    /// </summary>
    public bool WaitPopPeerAction()
    {


        return true;
    }

    private string LocalGameFileName => $"{Session.GameToken}.sugma";

    private string LocalGameFileTurnName(int turn)
    {
        return $"{Session.GameToken}.{turn}.bofa";
    }

    private bool AppendCommandToGameFile(SequencerCommand command, bool mustExist)
    {
        if(IsLocal)
        {
            var fileName = Path.Combine(InstanceConfiguration.LocalDataPath, LocalGameFileName);

            if(mustExist)
            {
                using var file = File.Open(fileName, FileMode.Open, FileAccess.Write, FileShare.Read);
                using var writer = new StreamWriter(file);

                writer.WriteLine(command.ToString());
            }
            else
            {
                File.WriteAllLines(fileName, [command.Command.ToString()]);
            }
        }
        else
        {
            // TODO:
        }

        return true;
    }

    private bool PushNewTurnFile(int turn, SequencerCommand command)
    {
        var fileName = Path.Combine(InstanceConfiguration.LocalDataPath, LocalGameFileTurnName(turn));

        File.WriteAllLines(fileName, [command.Command.ToString()]);

        return true;
    }

    internal bool TryJoin()
    {
        return WaitPopPeerAction();
    }
}
