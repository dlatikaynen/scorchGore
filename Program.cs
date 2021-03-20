using System;
using System.Windows.Forms;

namespace ScorchGore
{
    static class Program
    {
        /// <summary>
        /// The Scorch Gore Game
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
