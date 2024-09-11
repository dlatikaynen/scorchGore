using ScorchGore.ApiClient;
using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.GameSession;
using System.Runtime.CompilerServices;

namespace ScorchGore.Sequencer;

public class GoreSequencer(GoreSession session, bool isLocal)
{
    public GoreSession Session => session;
    public bool IsLocal => isLocal;

    public Queue<SequencerCommand> CommandQueue = new();
    public List<SequencerCommand> ProcessedCommands = [];

    public SequencerCommand ConsumeOne()
    {
        var consumed = CommandQueue.Dequeue();

        ProcessedCommands.Add(consumed);

        return consumed;
    }

    public List<SequencerCommand> ConsumeToEnd()
    {
        var consumed = new List<SequencerCommand>();

        while (CommandQueue.TryDequeue(out var item))
        {
            consumed.Add(item);
        }

        ProcessedCommands.AddRange(consumed);

        return consumed;
    }

    public bool MyTurnPushCommand(List<SequencerCommand> commands)
    {
        if (session.AmITheInitiatorEven && session.Watermark == 0)
        {
            var firstCommand = commands.First();
            if(firstCommand.Command != SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE)
            {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
                throw new ArgumentOutOfRangeException(nameof(SequencerCommand.Command), firstCommand.Command, $"First turn can only be {SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE}");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
            }

            /* new game starts, we write the file for the first time */
            return AppendCommandsToGameFile(commands, false);
        }

#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        if (session.AmITheInitiatorEven && int.IsEvenInteger(session.Watermark))
        {
            throw new ArgumentOutOfRangeException(nameof(session.Watermark), session.Watermark, nameof(session.AmITheInitiatorEven));
        }
        else if(session.AmIThePeerOdd && int.IsOddInteger(session.Watermark))
        {
            throw new ArgumentOutOfRangeException(nameof(session.Watermark), session.Watermark, nameof(session.AmIThePeerOdd));
        }
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

        if (PushNewTurnFile(Session.Watermark + 1, commands))
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
    public bool PollPopPeerAction()
    {
        if (Session.AmITheInitiatorEven)
        {
            /* read the other's stuff only, which is odd (the stuff, not reading it) */
            var head = Session.Watermark;

            if (head == 0 || int.IsEvenInteger(head))
            {
                ++head;
            }

            return PendingEventsToQueue(head);
        }
        else if (Session.AmIThePeerOdd)
        {
            /* read the other's stuff only, which is even, and includes the original file */
            if(Session.Watermark == 0)
            {
                return PendingEventsToQueue(0);
            }
            else
            {
                var start = Session.Watermark;
                
                if(int.IsOddInteger(start))
                {
                    ++start;
                }

                return PendingEventsToQueue(start);
            }
        }

        return false;
    }

    private bool PendingEventsToQueue(int queuePosition)
    {
        var anyItems = false;

        if (isLocal)
        {
            var expectedFile = Path.Combine(
                InstanceConfiguration.LocalSharedDataPath,
                LocalGameFileTurnName(queuePosition)
            );

            if (File.Exists(expectedFile))
            {
                var lines = File.ReadLines(expectedFile);

                foreach (var line in lines)
                {
                    CommandQueue.Enqueue(SequencerCommand.FromLine(line));
                    anyItems = true;
                }

                if (queuePosition > Session.Watermark)
                {
                    Session.Watermark = queuePosition;
                }

                if (queuePosition != 0)
                {
                    var localGameFile = Path.Combine(
                        InstanceConfiguration.LocalSharedDataPath,
                        LocalGameFileName
                    );

                    File.AppendAllLines(localGameFile, lines);
                    File.Delete(expectedFile);
                }
            }
        }
        else
        {
            (var success, var payload) = GoreApiClient.Pop(Session.GameToken, queuePosition);
            
            if(success)
            {
                foreach (var line in payload)
                {
                    CommandQueue.Enqueue(SequencerCommand.FromLine(line));
                    anyItems = true;
                }

                if (queuePosition > Session.Watermark)
                {
                    Session.Watermark = queuePosition;
                }
            }
        }

        return anyItems;
    }

    private string LocalGameFileName => $"{Session.GameToken}.sugma";

    private string LocalGameFileTurnName(int turn)
    {
        if(turn == 0)
        {
            return LocalGameFileName;
        }

        return $"{Session.GameToken}.{turn}.bofa";
    }

    private bool AppendCommandsToGameFile(List<SequencerCommand> commands, bool mustExist)
    {
        if(IsLocal)
        {
            var fileName = Path.Combine(InstanceConfiguration.LocalSharedDataPath, LocalGameFileName);

            if(mustExist)
            {
                using var file = File.Open(fileName, FileMode.Open, FileAccess.Write, FileShare.Read);
                using var writer = new StreamWriter(file);

                foreach (var command in commands)
                {
                    writer.WriteLine(command.ToString());
                }
            }
            else
            {
                File.WriteAllLines(fileName, commands.Select(c => c.ToString()!));
            }
        }
        else
        {
            if(mustExist)
            {
                // the server should do the appending
            }
            else
            {
                // this is the only time an online initiate will succeed: file must not exist
                GoreApiClient.InitiateGame(
                    Session.GameToken,
                    string.Join(Environment.NewLine, commands.Select(c => c.ToString()!))
                );
            }
        }

        ProcessedCommands.AddRange(commands);

        return true;
    }

    private bool PushNewTurnFile(int turn, List<SequencerCommand> commands)
    {
        if (turn <= 0 || commands.Count == 0)
        {
            return false;
        }

        if (IsLocal)
        {
            var fileName = Path.Combine(
                InstanceConfiguration.LocalSharedDataPath,
                LocalGameFileTurnName(turn)
            );

            File.WriteAllLines(fileName, commands.Select(c => c.ToString()));
            ProcessedCommands.AddRange(commands);
        }
        else
        {
            return GoreApiClient.Turn(Session.GameToken, turn, commands.Select(c => c.ToString()).ToArray());
        }

        return true;
    }

    internal bool TryJoin(SSP mySSP)
    {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
        if (Session.AmITheInitiatorEven)
        {
            throw new ArgumentOutOfRangeException(nameof(Session.AmITheInitiatorEven), Session.AmITheInitiatorEven, "Initiator cannot join their own game as the peer");
        }

        if(Session.Watermark != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(Session.Watermark), Session.Watermark, "Peer cannot join a game from the start when the game is already on");
        }
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

        if (PollPopPeerAction())
        {
            if(CommandQueue.TryPeek(out var command))
            {
                if (command.Command == SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE)
                {
                    ConsumeToEnd();

                    var commands = new List<SequencerCommand>()
                    {
                        new() { Command = SequencerCommands.OHAI, Arguments = InstanceSettings.PlayerName }
                    };

                    switch(mySSP)
                    {
                        case SSP.Scissors:
                            commands.Add(new() { Command = SequencerCommands.I_HAVE_SCISSORS, Arguments = InstanceSettings.PlayerName });
                            break;

                        case SSP.Stone:
                            commands.Add(new() { Command = SequencerCommands.I_HAVE_STONE, Arguments = InstanceSettings.PlayerName });
                            break;

                        case SSP.Paper:
                            commands.Add(new() { Command = SequencerCommands.I_HAVE_PAPER, Arguments = InstanceSettings.PlayerName });
                            break;

                        case SSP.Well:
                            commands.Add(new() { Command = SequencerCommands.I_HAVE_BRONNEN, Arguments = InstanceSettings.PlayerName });
                            break;
                    }

                    if (PushNewTurnFile(Session.Watermark + 1, commands))
                    {
                        ++Session.Watermark;

                        return true;
                    }
                }
            }
        }

        return false;
    }
}
