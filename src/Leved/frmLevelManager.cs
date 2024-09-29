using ScorchGore.Classes;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmLevelManager : Form
{
    private readonly GoreLeved _leved;
    private readonly frmLeved _levedWindow;

    public frmLevelManager()
    {
        InitializeComponent();

        _leved = new GoreLeved();
        _levedWindow = new frmLeved(_leved);
    }

    private void tvLevels_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var key = e.Node.Name.ToString();
        var keyParts = key.Split('.');

        if (keyParts.Length == 3 && int.TryParse(keyParts.Last(), out var levelNr))
        {
            _leved.Initialize(levelNr);

            if (_levedWindow.Visible)
            {
                _levedWindow.BringToFront();
            }
            else
            {
                _levedWindow.Text = e.Node.Text;
                _levedWindow.MdiParent = ParentForm?.MdiParent;
                _levedWindow.Show();
            }
        }
    }

    private void frmLevelManager_Load(object sender, EventArgs e)
    {
        tvLevels.Nodes.Clear();

        var installmentOne = tvLevels.Nodes.Add(
            "1",
            Xlat.µ(11),  // Instalment I: Wrath of the Mild
            null
        );

        var levelNr = 1;

        for (var mission = 1; mission <= 7; ++mission)
        {
            var missionNode = installmentOne.Nodes.Add(
                $"1.{mission}",
                LevelBeschreibung.MissionsnameBestimmen(mission),
                null
            );

            var levelInfo = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
            while (levelInfo.MissionsNummer == mission)
            {
                missionNode.Nodes.Add(
                    $"1.{mission}.{levelInfo.LevelNummer}",
                    levelInfo.LevelName,
                    null
                );

                ++levelNr;
                levelInfo = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
            }
        }

        var customLevels = tvLevels.Nodes.Add(
            "69",
            Xlat.µ(12), // My levels
            null
        );

        var customMission = customLevels.Nodes.Add(
            "69.1",
            Xlat.µ(13), // My mission
            null
        );

        var _ = customMission.Nodes.Add(
            "69.1.1",
            Xlat.µ(14), // Horror vacui
            null
        );
    }

    private void mnuToolsEditLevel_Click(object sender, EventArgs e)
    {
        tvLevels_NodeMouseDoubleClick(sender, new TreeNodeMouseClickEventArgs(
            tvLevels.SelectedNode,
            MouseButtons.None,
            0,
            0,
            0
        ));
    }
}
