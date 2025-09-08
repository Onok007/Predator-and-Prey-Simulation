using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace PredatorAndPreySimulation.UI
{
    /// <summary>
    /// Separate window with a chart showing population dynamics
    /// of prey and predators during the simulation.
    /// </summary>
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();

            // Create chart area (coordinate system)
            var area = new ChartArea("MainArea");
            chart.ChartAreas.Add(area);

            // Prey population line (green)
            var preySeries = new Series("Prey");
            preySeries.ChartType = SeriesChartType.Line;
            preySeries.Color = Color.Green;
            preySeries.BorderWidth = 2;
            chart.Series.Add(preySeries);

            // Predator population line (red)
            var predatorSeries = new Series("Predators");
            predatorSeries.ChartType = SeriesChartType.Line;
            predatorSeries.Color = Color.Red;
            predatorSeries.BorderWidth = 2;
            chart.Series.Add(predatorSeries);

            // Axis labels
            chart.ChartAreas[0].AxisX.Title = "Simulation steps";
            chart.ChartAreas[0].AxisY.Title = "Number of organisms";
        }

        /// <summary>
        /// Adds a new data point for current tick.
        /// Thread-safe (can be called from simulation thread).
        /// </summary>
        public void AddDataPoint(int tick, int preyCount, int predatorCount)
        {
            if (chart.InvokeRequired)
            {
                // Invoke on UI thread
                chart.Invoke(new MethodInvoker(() => AddDataPoint(tick, preyCount, predatorCount)));
            }
            else
            {
                chart.Series["Prey"].Points.AddXY(tick, preyCount);
                chart.Series["Predators"].Points.AddXY(tick, predatorCount);
            }
        }
    }
}
