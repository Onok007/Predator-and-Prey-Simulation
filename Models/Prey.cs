using System.Drawing;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Represents a prey organism in the simulation.
    /// Prey can move randomly, reproduce, and die due to overpopulation.
    /// </summary>
    public class Prey : Organism
    {
        private readonly SimulationConfig config;

        /// <summary>
        /// Steps since this prey was last reproduced.
        /// Used to control reproduction rate.
        /// </summary>
        private int stepsSinceBirth = 0;

        /// <summary>
        /// Possible movement directions (up, down, left, right).
        /// </summary>
        private static readonly (int dx, int dy)[] directions =
        {
            (1, 0), (-1, 0), (0, 1), (0, -1)
        };

        /// <summary>
        /// Creates a new prey at given coordinates using the provided config.
        /// </summary>
        public Prey(int x, int y, SimulationConfig config) : base(x, y)
        {
            this.config = config;
        }

        /// <summary>
        /// Updates the prey's state for one simulation step:
        /// - increases age
        /// - checks overpopulation (may die)
        /// - attempts to move randomly
        /// - attempts to reproduce if reproduction threshold is reached
        /// </summary>
        public override void Update(Grid grid, System.Random rand, List<Organism> newOrganisms)
        {
            Age++;
            stepsSinceBirth++;

            if (CheckOverpopulation(grid))
                return; // prey dies due to overcrowding

            TryMove(grid, rand);
            TryReproduce(grid, rand, newOrganisms);
        }

        /// <summary>
        /// Checks if the prey should die due to overpopulation.
        /// Returns true if the prey dies and is removed from the grid.
        /// </summary>
        private bool CheckOverpopulation(Grid grid)
        {
            if (config.PreyOverpopulationLimit == 0)
                return false; // feature disabled

            int neighbors = 0;
            for (int ox = -1; ox <= 1; ox++)
            {
                for (int oy = -1; oy <= 1; oy++)
                {
                    if (ox == 0 && oy == 0) continue;

                    int nx = X + ox;
                    int ny = Y + oy;

                    if (grid.IsInside(nx, ny) && grid.Cells[nx, ny] is Prey)
                        neighbors++;
                }
            }

            if (neighbors >= config.PreyOverpopulationLimit)
            {
                grid.Cells[X, Y] = null; // prey dies
                return true;
            }

            return false;
        }

        /// <summary>
        /// Attempts to move the prey one step in a random direction.
        /// Movement is only possible if the target cell is inside the grid and empty.
        /// </summary>
        private void TryMove(Grid grid, System.Random rand)
        {
            var (dx, dy) = directions[rand.Next(directions.Length)];
            int newX = X + dx;
            int newY = Y + dy;

            if (grid.IsInside(newX, newY) && grid.Cells[newX, newY] == null)
            {
                grid.Cells[X, Y] = null; // clear old position
                X = newX;
                Y = newY;
                grid.Cells[X, Y] = this; // occupy new cell
            }
        }

        /// <summary>
        /// Attempts to reproduce if enough steps have passed since birth.
        /// Reproduction occurs by placing a new prey in an adjacent empty cell.
        /// </summary>
        private void TryReproduce(Grid grid, System.Random rand, List<Organism> newOrganisms)
        {
            if (stepsSinceBirth < config.PreyReproductionRate)
                return;

            stepsSinceBirth = 0;

            foreach (var (dx, dy) in directions)
            {
                int bx = X + dx;
                int by = Y + dy;
                if (grid.IsInside(bx, by) && grid.Cells[bx, by] == null)
                {
                    var baby = new Prey(bx, by, config);
                    newOrganisms.Add(baby);
                    break; // reproduce only once per cycle
                }
            }
        }

        /// <summary>
        /// Draws the prey as a green square on the grid.
        /// </summary>
        public override void Draw(Graphics g, int cellSize)
        {
            g.FillRectangle(Brushes.Green, X * cellSize, Y * cellSize, cellSize, cellSize);
        }
    }
}
