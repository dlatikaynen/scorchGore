using ScorchGore.Classes;
using ScorchGore.Constants;
using System.Globalization;
using Xlat = ScorchGore.Translation.Translation;

namespace ScorchGore.Forms;

public partial class frmMaterialPalette : Form
{
    private List<Button> paletteButtons = [];
    private List<Material> selectedItems = [];

    public frmMaterialPalette()
    {
        InitializeComponent();
    }

    private Material? SelectedItem => selectedItems.SingleOrDefault();

    internal void Prepare(MaterialTheme theme)
    {
        lstBehavior.Items.Clear();

        var contentfulMedia = new List<Medium>();
        var mentionedMedia = new List<Medium>();

        foreach (var set in theme.SetsOfMaterials)
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
                theme.SetsOfMaterials.Add(new(existingMedium, []));
            }
        }

        lstBehavior.Items.AddRange([.. theme.SetsOfMaterials]);

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
        ClearError();

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
        ttpTips.SetToolTip(button, material.Name);
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (lstBehavior.SelectedItem is SetOfMaterials set)
        {
            if(paletteButtons.Count == 16 * 16)
            {
                lblInfo.Text = Xlat.µ(78); // The palette for this material is full, no room for more

                return;
            }

            var name = txtName.Text.Trim().ToUpperInvariant();

            if (!IsValidMaterialName(name, suppressMessage: false))
            {
                return;
            }

            var color = ParseUserColor(suppressMessage: false);

            if (color != null)
            {
                // colors need to be unique across the entire
                // set of materials because they are the only
                // thing the engine looks at when determining
                // a material from an arena pixel
                if (IsDuplicateColor(color.Value, self: null, suppressMessage: false))
                {
                    return;
                }

                ClearError();

                var material = new Material(name, color.Value);

                set.Materials.Add(material);
                AddPaletteButton(material);

                // a single manually added item is automatically
                // the selected item, so name edits, color edits,
                // and the delete button pertain to it right away
                selectedItems.Add(material);
            }
        }
        else
        {
            lblInfo.Text = Xlat.µ(73); // Select a primary medium first
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

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstBehavior.SelectedItem is SetOfMaterials set)
        {
            if (SelectedItem != null && ReferenceEquals(SelectedItem, set.Materials.Last()))
            {
                // we can just remove the last one quickly
                fmePalette.Controls.Remove(paletteButtons.Last());
                paletteButtons.Remove(paletteButtons.Last());
                selectedItems.Clear();
            }
            else if (selectedItems.Count != 0)
            {
                // we recreate the entire grid instead of shifting stuff
                var originalCursor = Cursor;

                Cursor = Cursors.WaitCursor;
                ClearPaletteButtons();

                set.Materials.RemoveAll(m => selectedItems.Contains(m));
                selectedItems.Clear();
                foreach (var material in set.Materials)
                {
                    AddPaletteButton(material);
                }

                Cursor = originalCursor;
            }
            else if(paletteButtons.Count == 0)
            {
                lblInfo.Text = Xlat.µ(77); // Ain't nothing there to remove 

                return;
            }
            else
            {
                lblInfo.Text = Xlat.µ(76); // Ain't nothing selected to remove   

                return;
            }
        }
        else
        {
            lblInfo.Text = Xlat.µ(73); // Select a primary medium first

            return;
        }

        ClearError();
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

    private bool IsDuplicateColor(Color color, Material? self, bool suppressMessage)
    {
        foreach (SetOfMaterials set in lstBehavior.Items)
        {
            foreach(var existing in set.Materials)
            {
                if(color.Equals(existing.Color))
                {
                    if(self == null || !ReferenceEquals(self, existing))
                    {
                        if (!suppressMessage)
                        {
                            if (lstBehavior.SelectedItem is SetOfMaterials current && current.Medium == set.Medium)
                            {
                                lblInfo.Text = Xlat.µ(
                                    80, // The "{0}" material in this palette already has the {1} color. Colors must be unique in each set
                                    existing.Name,
                                    $"#{color}"
                                );
                            }
                            else
                            {
                                lblInfo.Text = Xlat.µ(
                                  79, // The "{0}" medium already defines material "{1}" with color {2}. Colors must be unique per each set
                                  set.Medium.ToString(),
                                  existing.Name,
                                  $"#{color}"
                                );
                            }
                        }

                        return true;
                    }
                }
            }
        }

        return false;
    }

    private bool IsValidMaterialName(string name, bool suppressMessage)
    {
        const string allowedChars = "_ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        if (!string.IsNullOrEmpty(name))
        {
            if (!char.IsAsciiDigit(name[0]) && name.ToCharArray().All(c => allowedChars.Contains(c)))
            {
                // names need to be unique inside a primary medium
                // (because if it is adressed, it is always addressed
                // in the context of exactly one primary medium)
                if (lstBehavior.SelectedItem is SetOfMaterials set)
                {
                    var dupe = set.Materials.FirstOrDefault(m => m.Name == name);

                    if (dupe != null && (SelectedItem == null || !ReferenceEquals(dupe, SelectedItem)))
                    {
                        if (!suppressMessage)
                        {
                            lblInfo.Text = Xlat.µ(75, name, dupe.Color.Name); // The name "{0}" has already been used for the {1} color in the current primary medium
                            txtName.Focus();
                        }

                        return false;
                    }
                }

                return true;
            }
        }

        if (!suppressMessage)
        {
            lblInfo.Text = Xlat.µ(74, allowedChars); // Names for materials can be used in level generator scripts. Therefore, they need to follow the rules for Holy C# identifiers: {0} only, and don't begin with a numeric digit
            txtName.Focus();
        }

        return false;
    }

    private void ClearError()
    {
        lblInfo.Text = lstBehavior.Text;
    }
}
