using System;
using System.Windows.Forms;
using PredatorAndPreySimulation.UI;

namespace PredatorAndPreySimulation
{
    /// <summary>
    /// Application entry point. 
    /// Initializes WinForms and starts the MainForm.
    /// </summary>
    internal static class Program
    {
        [STAThread] // required for WinForms (uses COM under the hood)
        static void Main()
        {
            // Enables modern UI styling
            Application.EnableVisualStyles();

            // Use GDI+ text rendering instead of legacy GDI
            Application.SetCompatibleTextRenderingDefault(false);

            // Start main application window
            Application.Run(new MainForm());
        }
    }
}
