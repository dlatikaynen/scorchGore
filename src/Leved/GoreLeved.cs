using ScorchGore.Arena;
using ScorchGore.Classes;

namespace ScorchGore.Leved;

public class GoreLeved
{
    public LevelBeschreibung EditedLevel = new();
    public frmLeved? Target { get; set; }

    private bool backDrop = false;

    public void Initialize(LevelBeschreibung level)
    {
        if (Target == null)
        {
            throw new NullReferenceException(nameof(Target));
        }

        if (!ReferenceEquals(EditedLevel, level))
        {
            LevedEvents.LevedPropertyChanged -= ListenPropertyChange;
        }

        EditedLevel = level;
        Target.SetupBackbuffer((int)EditedLevel.Width, (int)EditedLevel.Height);
        EditedLevel.Materials.PrepareForLevel(EditedLevel);
        UpdateBackdrop();
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
        LevedEvents.LevedPropertyChanged += ListenPropertyChange;
    }

    private void UpdateBackdrop()
    {
        if (Target == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(EditedLevel.BackdropAssetKey))
        {
            backDrop = false;
        }
        else 
        { 
            var bkdr = DesignWorkspace.Assets.SingleOrDefault(a => a.Name == EditedLevel.BackdropAssetKey);

            if (bkdr != null)
            {
                using var inFile = File.OpenRead($@".\{bkdr.Id:D}.lump");
                Target.Backdrop = new(Image.FromStream(inFile, useEmbeddedColorManagement: true, validateImageData: true));
                backDrop = true;
            }
        }

        if (!backDrop && Target.Backdrop != null)
        {
            Target.Backdrop?.Dispose();
            Target.Backdrop = null;
        }
    }

    private void ListenPropertyChange(object sender, LevedEvents.LevedPropertyChangedEventArgs e)
    {
        if (Target == null)
        {
            return;
        }

        var shouldHaveBackdrop = !string.IsNullOrEmpty(EditedLevel.BackdropAssetKey);

        if (shouldHaveBackdrop != backDrop)
        {
            UpdateBackdrop();
        }

        EditedLevel.Materials.PrepareForLevel(EditedLevel);
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
    }
}
