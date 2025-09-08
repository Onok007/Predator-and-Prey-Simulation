namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Configuration values for simulation rules. 
    /// Defines reproduction, overpopulation and predator energy mechanics.
    /// </summary>
    public class SimulationConfig
    {
        /// <summary>
        /// Number of steps after which a prey attempts to reproduce.
        /// </summary>
        public int PreyReproductionRate { get; set; } = 8;

        /// <summary>
        /// Maximum number of prey neighbors allowed before dying.
        /// 0 means the limit is disabled.
        /// </summary>
        public int PreyOverpopulationLimit { get; set; } = 0;

        /// <summary>
        /// Amount of energy a predator gains by eating one prey.
        /// </summary>
        public int PredatorEnergyGain { get; set; } = 6;

        /// <summary>
        /// Minimum energy required for predator reproduction.
        /// </summary>
        public int PredatorReproductionThreshold { get; set; } = 20;
    }
}
