using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore.Steuerelemente
{
    internal static class ControlExtensions
    {
        public static void Center(this Control controlToCenter, Control parentContainer)
        {
            controlToCenter.Location = new Point(
                parentContainer.Width / 2 - controlToCenter.Width / 2,
                parentContainer.Height / 2 - controlToCenter.Height / 2
            );
        }
    }
}
