using ScorchGore.Configuration;
using ScorchGore.Constants;
using ScorchGore.Sequencer;

namespace ScorchGore.GameSession;

public class GoreSession
{
    public Guid GameToken { get; set; }

    public bool AmITheInitiatorEven { get; set; }

    public bool AmIThePeerOdd => !AmITheInitiatorEven;

    public GoreSequencer? _sequencer;

    public GoreSequencer Sequencer => _sequencer ?? new GoreSequencer(this, true);

    public int Watermark { get; set; } = 0;

    public bool Initiate()
    {
        GameToken = Guid.NewGuid();
        AmITheInitiatorEven = true;

        _sequencer = new(this, isLocal: false);
        return Sequencer.MyTurnPushCommand(
        [
            new SequencerCommand { Command = SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE },
            new SequencerCommand { Command = SequencerCommands.HELO, Arguments = InstanceSettings.PlayerName }
        ]);
    }

    public bool Join(Guid token, SSP mySsp)
    {
        GameToken = token;
        AmITheInitiatorEven = false;
        _sequencer = new(this, isLocal: false);

        return _sequencer.TryJoin(mySsp);
    }

    public bool HasPeerJoined(SSP mySsp)
    {
        if (_sequencer?.PollPopPeerAction() ?? false)
        {
            if (Watermark > 0 && Sequencer.CommandQueue.TryPeek(out var expectingEhlo) && expectingEhlo.Command == SequencerCommands.OHAI)
            {
                /* now it is time to determine who won the SSP */
                Sequencer.ConsumeOne();

                if (Sequencer.CommandQueue.TryPeek(out var expectingSSP))
                {
                    var theirChoice = SSP.None;

                    Sequencer.ConsumeToEnd();
                    switch(expectingSSP.Command)
                    {
                        case SequencerCommands.I_HAVE_SCISSORS:
                            theirChoice = SSP.Scissors;
                            break;

                        case SequencerCommands.I_HAVE_STONE:
                            theirChoice = SSP.Stone;
                            break;

                        case SequencerCommands.I_HAVE_PAPER:
                            theirChoice = SSP.Paper;
                            break;

                        case SequencerCommands.I_HAVE_BRONNEN:
                            theirChoice = SSP.Well;
                            break;
                    }

                    var iWon = false;
                    var iHad = SequencerCommands.MY_TURN;

                    switch (mySsp)
                    {
                        case SSP.Scissors:
                            iHad = theirChoice == mySsp ? SequencerCommands.I_HAD_SCISSORS_FIRST : SequencerCommands.I_HAD_SCISSORS;
                            break;

                        case SSP.Stone:
                            iHad = theirChoice == mySsp ? SequencerCommands.I_HAD_STONE_FIRST : SequencerCommands.I_HAD_STONE;
                            break;

                        case SSP.Paper:
                            iHad = theirChoice == mySsp ? SequencerCommands.I_HAD_PAPER_FIRST : SequencerCommands.I_HAD_PAPER;
                            break;

                        case SSP.Well:
                            iHad = theirChoice == mySsp ? SequencerCommands.I_HAD_BRONNEN_FIRST : SequencerCommands.I_HAD_BRONNEN;
                            break;
                    }

                    if (mySsp == SSP.None || theirChoice == SSP.None)
                    {
                        // no SSP played. courtesy peer first
                    }
                    if (theirChoice == mySsp)
                    {
                        iWon = true;
                    }
                    else
                    {
                        // canonical rules with well
                        switch (mySsp)
                        {
                            case SSP.Scissors:
                                /* stein schlägt schere, schere fällt in brunnen */
                                iWon = theirChoice != SSP.Stone && theirChoice != SSP.Well;
                                break;

                            case SSP.Stone:
                                /* papier wickelt stein ein, stein fällt in brunnen */
                                iWon = theirChoice != SSP.Paper && theirChoice != SSP.Well;
                                break;

                            case SSP.Paper:
                                /* schere schneidet papier */
                                iWon = theirChoice != SSP.Scissors;
                                break;

                            case SSP.Well:
                                /* papier deckt brunnen zu */
                                iWon = theirChoice != SSP.Paper;
                                break;
                        }
                    }

                    var communique = new List<SequencerCommand>();

                    if(mySsp != SSP.None)
                    {
                        communique.Add(new() { Command = iHad });
                    }

                    communique.Add(new() { Command = SequencerCommands.CANVAS_THE_CITY_AND_BRUSH_THE_BACKDROP });
                    if (iWon)
                    {
                        communique.Add(new() { Command = SequencerCommands.MY_TURN });
                    }

                    return Sequencer.MyTurnPushCommand(communique);
                }

                return true;
            }
        }

        return false;
    }
}
