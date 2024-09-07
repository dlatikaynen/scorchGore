using ScorchGore.Configuration;
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

        _sequencer = new(this, true);
        return Sequencer.MyTurnPushCommand(
        [
            new SequencerCommand { Command = SequencerCommands.SATTELT_DIE_HUEHNER_WIR_REITEN_INS_GEBIRGE },
            new SequencerCommand { Command = SequencerCommands.HELO, Arguments = InstanceSettings.PlayerName }
        ]);
    }

    public bool Join(Guid token)
    {
        GameToken = token;
        AmITheInitiatorEven = false;

        _sequencer = new(this, true);
        return _sequencer.TryJoin();
    }

    public bool HasPeerJoined()
    {
        return _sequencer?.PollPopPeerAction() ?? false;
    }
}
