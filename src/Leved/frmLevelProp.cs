using ScorchGore.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScorchGore.Leved;

public partial class frmLevelProp : Form
{
    public frmLevelProp()
    {
        InitializeComponent();
    }

    internal void Prepare(LevelProperties properties)
    {
        ppgTable.SelectedObject = properties;
    }
}
