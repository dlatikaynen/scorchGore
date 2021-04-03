using System.Drawing;
using System.Windows.Forms;

public class DurchsichtigesLabel : Label
{
    private const int WS_EX_TRANSPARENT = 0x00000020;
    private const int WM_PAINT = 0x0F;
    private const int WM_ERASEBKGND = 0x14;

    public bool Transparent { get; set; }

    protected override CreateParams CreateParams
    {
        get
        {
            if (this.Transparent)
            {
                var cp = base.CreateParams;
                cp.ExStyle |= DurchsichtigesLabel.WS_EX_TRANSPARENT;
                return cp;
            }
            
            return base.CreateParams;
        }
    }

    protected override void WndProc(ref Message m)
    {
        if (this.Transparent)
        {
            if (m.Msg != DurchsichtigesLabel.WM_ERASEBKGND && m.Msg != DurchsichtigesLabel.WM_PAINT)
            {
                base.WndProc(ref m);
            }
            else
            {
                if (m.Msg == DurchsichtigesLabel.WM_PAINT) 
                {
                    base.OnPaint(new PaintEventArgs(Graphics.FromHwnd(Handle), this.ClientRectangle));
                }

                this.DefWndProc(ref m);
            }
        }
        else
        {
            base.WndProc(ref m);
        }
    }
}