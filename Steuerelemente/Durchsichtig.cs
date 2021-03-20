using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Durchsichtig : Panel
{
    private const int WS_EX_TRANSPARENT = 0x20;

    private int opacity = 50;

    public Durchsichtig()
    {
        this.SetStyle(ControlStyles.Opaque, true);
    }

    [DefaultValue(50)]
    public int Opacity
    {
        get
        {
            return this.opacity;
        }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Opacity), value, "value must be between 0 and 100");
            }

            this.opacity = value;
        }
    }
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
            return cp;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using (var brush = new SolidBrush(Color.FromArgb(this.opacity * 0xff / 100, this.BackColor)))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        base.OnPaint(e);
    }
}