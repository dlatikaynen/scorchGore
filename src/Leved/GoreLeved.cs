using ScorchGore.Arena;
using ScorchGore.Classes;

namespace ScorchGore.Leved;

public class GoreLeved
{
    public LevelBeschreibung EditedLevel = new();
    public frmLeved? Target { get; set; }

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
        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
        LevedEvents.LevedPropertyChanged += ListenPropertyChange;
    }

    private void ListenPropertyChange(object sender, LevedEvents.LevedPropertyChangedEventArgs e)
    {
        if (Target == null)
        {
            return;
        }

        EditedLevel.Materials.Bergfarbe = EditedLevel.ColorMountain;

        var backDrop = false;
        if (!string.IsNullOrEmpty(EditedLevel.BackdropAssetKey))
        {
            var bkdr = DesignWorkspace.Assets.SingleOrDefault(a => a.Name == EditedLevel.BackdropAssetKey);

            if(bkdr != null)
            {
                using var inFile = File.OpenRead($@".\{bkdr.Id:D}.lump");
                Target.Backdrop = new(Image.FromStream(inFile, useEmbeddedColorManagement: true, validateImageData: true));
                backDrop = true;
            }
        }

        if (!backDrop)
        {
            Target.Backdrop?.Dispose();
            Target.Backdrop = null;
        }

        LevelZeichner.Zeichne(Target.Image, EditedLevel, Target.BackBuffer);
    }
}
