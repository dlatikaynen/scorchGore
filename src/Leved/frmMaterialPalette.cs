using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Globalization;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Forms;

public partial class frmMaterialPalette : Form
{
    private List<Button> paletteButtons = [];

    public frmMaterialPalette()
    {
        InitializeComponent();
    }

    internal void Prepare(List<SetOfMaterials> sets)
    {
        lstBehavior.Items.Clear();

        var contentfulMedia = new List<Medium>();
        var mentionedMedia = new List<Medium>();

        foreach (var set in sets)
        {
            if (!mentionedMedia.Contains(set.Medium))
            {
                mentionedMedia.Add(set.Medium);
            }

            if (set.Materials.Count > 0 && !contentfulMedia.Contains(set.Medium))
            {
                contentfulMedia.Add(set.Medium);
            }
        }

        var existingMedia = Enum.GetValues<Medium>();
        foreach (var existingMedium in existingMedia)
        {
            if (!mentionedMedia.Contains(existingMedium))
            {
                sets.Add(new(existingMedium, []));
            }
        }

        // make entries which are contentful bold
        lstBehavior.Items.AddRange([.. sets]);
        foreach (var contentfulSet in contentfulMedia)
        {

        }

        // preselect the first behavior with any entries
        foreach (SetOfMaterials entry in lstBehavior.Items)
        {
            if (entry.Materials.Count > 0)
            {
                lstBehavior.SelectedItem = entry;

                break;
            }
        }
    }

    private void lstBehavior_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearPaletteButtons();
        lblInfo.Text = lstBehavior.Text;

        if (lstBehavior.SelectedItem is SetOfMaterials set)
        {
            foreach (var material in set.Materials)
            {
                AddPaletteButton(material);
            }
        }
    }

    private void ClearPaletteButtons()
    {
        for (var i = paletteButtons.Count - 1; i >= 0; i--)
        {
            fmePalette.Controls.Remove(paletteButtons[i]);
            paletteButtons.RemoveAt(i);
        }
    }

    private void AddPaletteButton(Material material)
    {
        var count = paletteButtons.Count;
        if (paletteButtons.Count >= 16 * 16)
        {
            return;
        }

        var row = count / 16;
        var col = count % 16;
        var button = new Button
        {
            BackColor = material.Color,
            Size = btnColor.Size,
            Location = btnColor.Location,
            FlatStyle = btnColor.FlatStyle,
            Margin = btnColor.Margin,
            Padding = btnColor.Padding,
            Text = btnColor.Text,
            Parent = fmePalette
        };

        button.Left += (button.Width + 1) * col;
        button.Top += (button.Height + 1) * row;

        paletteButtons.Add(button);
        fmePalette.Controls.Add(button);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (lstBehavior.SelectedItem is SetOfMaterials set)
        {
            var color = ParseUserColor(suppressMessage: false);

            if (color != null)
            {
                var material = new Material("name", color.Value);

                set.Materials.Add(material);
                AddPaletteButton(material);
            }
        }
    }

    private void btnColorPicker_Click(object sender, EventArgs e)
    {
        if (dlgColor.ShowDialog(this) == DialogResult.OK)
        {
            var c = dlgColor.Color;
            txtColor.Text = $"#{c.A:X}{c.R:X}{c.G:X}{c.B:X}".ToLowerInvariant();
        }
    }

    private Color? ParseUserColor(bool suppressMessage)
    {
        var s = txtColor.Text.Trim();

        if (string.IsNullOrWhiteSpace(s))
        {
            return null;
        }

        if (s.Length != "#aarrggbb".Length)
        {
            if (s.Length == "#rrggbb".Length)
            {
                s = $"#ff{s[1..]}";
            }
            else
            {
                goto Invalid;
            }
        }

        s = s.ToUpperInvariant();

        var aPart = s.Substring(1, 2);
        var rPart = s.Substring(3, 2);
        var gPart = s.Substring(5, 2);
        var bPart = s.Substring(7, 2);

        if (byte.TryParse(aPart, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var a) &&
            byte.TryParse(rPart, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var r) &&
            byte.TryParse(gPart, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var g) &&
            byte.TryParse(bPart, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var b))
        {
            return Color.FromArgb(a, r, g, b);
        }

    Invalid:
        if (!suppressMessage)
        {
            lblInfo.Text = string.Format(Xlat.µ(72), s); // Whatever "{0}" is supposed to be, a hex color spec it is not. The format is #aarrggbb, example #ff00ff00 for solid green, example #770000ff for semi-transparent blue
        }

        return null;
    }
}
