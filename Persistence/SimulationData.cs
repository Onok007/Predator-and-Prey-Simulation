using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Persistence
{
    /// <summary>
    /// Serializable data transfer object (DTO) 
    /// representing the whole simulation state.
    /// Contains grid size, organisms, and configuration.
    /// </summary>
    public class SimulationData
    {
        /// <summary>
        /// Size of the simulation grid (width/height).
        /// </summary>
        public int GridSize { get; set; }

        /// <summary>
        /// List of all organisms in the grid.
        /// </summary>
        public List<OrganismData> Organisms { get; set; } = new List<OrganismData>();

        /// <summary>
        /// Simulation rules/configuration at the time of saving.
        /// </summary>
        public SimulationConfig Config { get; set; } = new SimulationConfig();
    }
}
