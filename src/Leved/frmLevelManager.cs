using ScorchGore.Classes;
using ScorchGore.Forms;
using System.Diagnostics;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Leved;

public partial class frmLevelManager : Form
{
    private readonly GoreLeved _leved;
    private readonly frmLeved _levedWindow;
    private readonly frmAssetPlacement _assetPlacement;
    private readonly frmLevelProp _levelProp;

    public frmLevelManager()
    {
        InitializeComponent();

        _leved = new GoreLeved();
        _levedWindow = new frmLeved(_leved);
        _assetPlacement = new frmAssetPlacement();
        _levelProp = new frmLevelProp();
    }

    private void frmLevelManager_Load(object sender, EventArgs e)
    {
        tvLevels.Nodes.Clear();
        DesignWorkspace.EnsureDesignWorkspace();

        var installmentOne = tvLevels.Nodes.Add(
            "1",
            Xlat.µ(11), // Instalment I: Wrath of the Mild
            null
        );

        var levelNr = 1;

        for (var mission = 1; mission <= 7; ++mission)
        {
            var missionNode = installmentOne.Nodes.Add(
                $"1.{mission}",
                LevelBeschreibung.MissionsnameBestimmen(mission),
                "mission",
                "mission"
            );

            var levelInfo = LevelSequenzierer.ErzeugeLevelBeschreibung(levelNr);
            while (levelInfo.MissionsNummer == mission)
            {
                var levelNode = missionNode.Nodes.Add(
                    $"1.{mission}.{levelInfo.LevelNummer}",
                    levelInfo.LevelName,
                    "map",
                    "map"
                );

                levelNode.Tag = levelInfo;

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
            "mission",
            "mission"
        );

        var _ = customMission.Nodes.Add(
            "69.1.1",
            Xlat.µ(14), // Horror vacui
            "map",
            "map"
        );

        Xlat.RegisterForTranslation(frmLevelManager_TranslationChanged);
    }

    private void frmLevelManager_TranslationChanged(object sender, Xlat.TranslationChangedEventArgs e)
    {
        Text = Xlat.µ(103); // Level Manager
        mnuTools.Text = Xlat.µ(104); // Design
        mnuToolsAddLevel.Text = Xlat.µ(97); // Add level...
        mnuToolsDeleteLevel.Text = Xlat.µ(98); // Delete level
        mnuToolsEditLevel.Text = Xlat.µ(99); // Edit level...
        mnuToolsAssetPlacement.Text = Xlat.µ(111); // Asset placement...
        mnuToolsLevelProperties.Text = Xlat.µ(100); // Level properties...
        mnuToolsPlaytestLevel.Text = Xlat.µ(101); // Playtest
        mnuToolsToolbox.Text = Xlat.µ(102); // Toolbox

        Xlat.TranslateTreeview(tvLevels);
    }

    private void tvLevels_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        var level = LevelNrFromNode(e.Node);

        if (level != null)
        {
            _leved.Initialize(level);
            _assetPlacement.Prepare(level);
            _levelProp.Prepare(level);

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

    private static LevelBeschreibung? LevelNrFromNode(TreeNode node)
    {
        var key = node.Name.ToString();
        var keyParts = key.Split('.');

        if (keyParts.Length == 3 && int.TryParse(keyParts.Last(), out var levelNr))
        {
            var props = node.Tag as LevelBeschreibung;

            Debug.Assert(props != null && props.LevelNummer == levelNr);

            return props;
        }

        return null;
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

    private void mnuToolsAssetPlacement_Click(object sender, EventArgs e)
    {
        var level = LevelNrFromNode(tvLevels.SelectedNode);

        if (level == null)
        {
            return;
        }

        if (!ReferenceEquals(_assetPlacement.EditedLevel, level))
        {
            _assetPlacement.Prepare(level);
        }

        if (_assetPlacement.Visible)
        {
            _assetPlacement.BringToFront();
        }
        else
        {
            _assetPlacement.MdiParent = MdiParent;
            _assetPlacement.Show();
        }
    }

    private void mnuToolsLevelProperties_Click(object sender, EventArgs e)
    {
        var level = LevelNrFromNode(tvLevels.SelectedNode);

        if (level == null)
        {
            return;
        }

        if (!ReferenceEquals(_levelProp.EditedLevel, level))
        {
            _levelProp.Prepare(level);
        }

        if (_levelProp.Visible)
        {
            _levelProp.BringToFront();
        }
        else
        {
            _levelProp.MdiParent = MdiParent;
            _levelProp.Show();
        }
    }

    private void frmLevelManager_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
