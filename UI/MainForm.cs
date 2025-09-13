using PredatorAndPreySimulation.Models;
using PredatorAndPreySimulation.Persistence;
using System.Text.Json;
using System.Windows.Forms;
using System;
using System.IO;

namespace PredatorAndPreySimulation.UI
{
    /// <summary>
    /// Main application window. 
    /// Handles user interaction, drawing canvas, 
    /// simulation lifecycle (start/pause/step/reset), 
    /// file saving/loading, and statistics display.
    /// </summary>
    public partial class MainForm : Form
    {
        private Simulation simulation;
        private SimulationConfig simulationConfig;
        private Timer timer;
        private StatisticsForm statsForm;

        /// <summary>
        /// Modes for grid editing (adding prey, predator, obstacle, erase).
        /// </summary>
        public enum EditMode { None, Prey, Predator, Obstacle, Erase }
        private EditMode currentMode = EditMode.None;

        /// <summary>
        /// Constructor. Initializes UI, simulation config, and timer.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Initialize config from NumericUpDown values
            simulationConfig = new SimulationConfig();
            simulationConfig.PreyOverpopulationLimit = (int)nudOverpop.Value;
            simulationConfig.PreyReproductionRate = (int)nudReproRate.Value;
            simulationConfig.PredatorEnergyGain = (int)nudEnergyGain.Value;
            simulationConfig.PredatorReproductionThreshold = (int)nudEnergyRepro.Value;

            // Initialize Simulation
            simulation = new Simulation(config: simulationConfig, (int)nudGridSize.Value);

            // Timer to update simulation periodically (100 ms ~ 10 FPS)
            timer = new Timer { Interval = 100 };
            timer.Tick += Timer_Tick;

            // Enable double buffering on canvas to reduce flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, panelCanvas, new object[] { true });
        }

        /// <summary>
        /// Timer tick event – advances simulation by one step and redraws.
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!simulation.IsRunning) return;
            simulation.Step();
            panelCanvas.Invalidate();
            UpdateStatistics();
        }

        /// <summary>
        /// Start simulation and start timer.
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            simulation.Start();
            timer.Start();
        }

        /// <summary>
        /// Pause simulation (timer keeps running but no steps are processed).
        /// </summary>
        private void btnPause_Click(object sender, EventArgs e)
        {
            simulation.Pause();
        }

        /// <summary>
        /// Execute one simulation step manually.
        /// </summary>
        private void btnStep_Click(object sender, EventArgs e)
        {
            simulation.Step();
            panelCanvas.Invalidate();
            UpdateStatistics();
        }

        /// <summary>
        /// Reset simulation with current config and grid size.
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            simulation = new Simulation(config: simulationConfig, (int)nudGridSize.Value);
            panelCanvas.Invalidate();
        }

        /// <summary>
        /// Apply parameters from UI (grid size, counts, config) and restart simulation.
        /// </summary>
        private void btnApplyInitParams_Click(object sender, EventArgs e)
        {
            int gridSize = (int)nudGridSize.Value;
            int preyCount = (int)nudPrey.Value;
            int predatorCount = (int)nudPredators.Value;
            int obstacleCount = (int)nudObstacles.Value;

            // Update config from UI
            simulationConfig.PreyOverpopulationLimit = (int)nudOverpop.Value;
            simulationConfig.PreyReproductionRate = (int)nudReproRate.Value;
            simulationConfig.PredatorEnergyGain = (int)nudEnergyGain.Value;
            simulationConfig.PredatorReproductionThreshold = (int)nudEnergyRepro.Value;

            // Restart simulation with new parameters
            simulation = new Simulation(simulationConfig, gridSize, preyCount, predatorCount, obstacleCount);

            panelCanvas.Invalidate();
        }

        private void btnApplyRuntimeParams_Click(object sender, EventArgs e)
        {
            if (!simulation.IsRunning)
            {
                simulationConfig.PreyOverpopulationLimit = (int)nudOverpop.Value;
                simulationConfig.PreyReproductionRate = (int)nudReproRate.Value;
                simulationConfig.PredatorEnergyGain = (int)nudEnergyGain.Value;
                simulationConfig.PredatorReproductionThreshold = (int)nudEnergyRepro.Value;
            }
            else
            {
                MessageBox.Show("Změnu parametrů proveďte prosím v režimu Pause.");
            }
        }

        /// <summary>
        /// Paint event – draws the grid and all organisms.
        /// </summary>
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            simulation.Draw(e.Graphics, panelCanvas.Width, panelCanvas.Height);
        }

        /// <summary>
        /// Mouse click on canvas – places organism depending on current edit mode.
        /// </summary>
        private void panelCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            int cellSize = Math.Min(panelCanvas.Width / simulation.Size, panelCanvas.Height / simulation.Size);
            int x = e.X / cellSize;
            int y = e.Y / cellSize;

            if (!simulation.IsInside(x, y)) return;

            switch (currentMode)
            {
                case EditMode.Prey: simulation.AddPrey(x, y); break;
                case EditMode.Predator: simulation.AddPredator(x, y); break;
                case EditMode.Obstacle: simulation.AddObstacle(x, y); break;
                case EditMode.Erase: simulation.RemoveOrganism(x, y); break;
            }

            panelCanvas.Invalidate();
        }

        // Radio buttons – switch current editing mode
        private void radioPrey_CheckedChanged(object sender, EventArgs e) => currentMode = EditMode.Prey;
        private void radioPred_CheckedChanged(object sender, EventArgs e) => currentMode = EditMode.Predator;
        private void radioObs_CheckedChanged(object sender, EventArgs e) => currentMode = EditMode.Obstacle;
        private void radioErase_CheckedChanged(object sender, EventArgs e) => currentMode = EditMode.Erase;

        /// <summary>
        /// Save current simulation state to JSON file.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (simulation == null) return;

            using (var sfd = new SaveFileDialog { Filter = "JSON files|*.json" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var data = simulation.ToData();
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(data, options);
                    File.WriteAllText(sfd.FileName, json);
                }
            }
        }

        /// <summary>
        /// Load simulation state from JSON file.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "JSON files|*.json" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(ofd.FileName);
                    var data = JsonSerializer.Deserialize<SimulationData>(json);
                    if (data != null)
                    {
                        simulation = Simulation.FromData(data);
                        panelCanvas.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Show statistics window and update with current values.
        /// </summary>
        private void btnStats_Click(object sender, EventArgs e)
        {
            if (statsForm == null || statsForm.IsDisposed)
                statsForm = new StatisticsForm();

            UpdateStatistics();
            statsForm.Show();
        }

        /// <summary>
        /// Add new data point to statistics form.
        /// </summary>
        private void UpdateStatistics()
        {
            if (simulation == null) return;

            var counts = simulation.CountOrganisms();
            if (statsForm != null && !statsForm.IsDisposed)
            {
                statsForm.AddDataPoint(simulation.Tick, counts.prey, counts.predators);
            }
        }

        /// <summary>
        /// Cleanup resources on closing.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer?.Stop();
            timer?.Dispose();
        }
    }
}
