using System.Drawing;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Represents a static obstacle on the grid.
    /// Obstacles do not move or interact, but they block movement.
    /// </summary>
    public class Obstacle : Organism
    {
        /// <summary>
        /// Creates a new obstacle at the given coordinates.
        /// </summary>
        public Obstacle(int x, int y) : base(x, y) { }

        /// <summary>
        /// Obstacles do nothing during updates.
        /// </summary>
        public override void Update(Grid grid, System.Random rand, List<Organism> newOrganisms)
        {
            // Static - no logic needed
        }

        /// <summary>
        /// Draws the obstacle as a black square on the grid.
        /// </summary>
        public override void Draw(Graphics g, int cellSize)
        {
            g.FillRectangle(Brushes.Black, X * cellSize, Y * cellSize, cellSize, cellSize);
        }
    }
}
