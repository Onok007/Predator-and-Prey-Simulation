namespace PredatorAndPreySimulation.Persistence
{
    /// <summary>
    /// Serializable data transfer object (DTO) 
    /// representing a single organism on the grid.
    /// Used when saving/loading simulation state.
    /// </summary>
    public class OrganismData
    {
        /// <summary>
        /// Type of organism ("Prey", "Predator", "Obstacle").
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// X-coordinate in the grid.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y-coordinate in the grid.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Age of the organism.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Energy (only relevant for predators, ignored otherwise).
        /// </summary>
        public int Energy { get; set; }
    }
}
