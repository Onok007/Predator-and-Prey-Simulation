using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System;

namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Represents a predator in the simulation.
    /// Predators can move, hunt prey within a vision range, reproduce, and die of starvation.
    /// </summary>
    public class Predator : Organism
    {
        private readonly SimulationConfig config;

        /// <summary>
        /// Current energy of the predator. Decreases every step,
        /// increases when eating prey, and splits during reproduction.
        /// </summary>
        public int Energy { get; private set; } = 5;

        /// <summary>
        /// Maximum distance (in cells) at which predator can detect prey.
        /// </summary>
        private readonly int visionRange = 5;

        /// <summary>
        /// Last known position of a prey (if seen).
        /// Predator will keep moving toward it until it is gone.
        /// </summary>
        private (int x, int y)? lastSeenPrey = null;

        public Predator(int x, int y, SimulationConfig config) : base(x, y)
        {
            this.config = config;
        }

        /// <summary>
        /// Allows restoring energy from save/load system.
        /// </summary>
        public void SetEnergy(int value)
        {
            Energy = value;
        }

        /// <summary>
        /// Main update method for the predator.
        /// Handles:
        /// - aging
        /// - prey detection and movement
        /// - hunting and energy management
        /// - death by starvation
        /// - reproduction if energy threshold is reached
        /// </summary>
        public override void Update(Grid grid, System.Random rand, List<Organism> newOrganisms)
        {
            Age++;

            HandlePerception(grid);

            var (newX, newY) = DecideNextMove(rand, grid);

            TryMove(grid, newX, newY);

            HandleEnergy(grid, newOrganisms);
        }

        /// <summary>
        /// Detects prey in the vision range and updates last seen position.
        /// </summary>
        private void HandlePerception(Grid grid)
        {
            var prey = FindClosestPrey(grid);
            if (prey != null)
                lastSeenPrey = (prey.X, prey.Y);
        }

        /// <summary>
        /// Decides whether to move toward prey or randomly.
        /// If predator loses sight of prey, lastSeenPrey is cleared.
        /// </summary>
        private (int x, int y) DecideNextMove(System.Random rand, Grid grid)
        {
            if (lastSeenPrey != null)
            {
                var (newX, newY) = MoveTowardsTarget(lastSeenPrey.Value);

                // If reached target cell but prey is not there anymore, forget it
                if (newX == lastSeenPrey.Value.x && newY == lastSeenPrey.Value.y &&
                    !(grid.Cells[newX, newY] is Prey))
                {
                    lastSeenPrey = null;
                }

                return (newX, newY);
            }
            else
            {
                return MoveRandom(rand);
            }
        }

        /// <summary>
        /// Handles starvation and reproduction after each move.
        /// </summary>
        private void HandleEnergy(Grid grid, List<Organism> newOrganisms)
        {
            Energy--;

            // Predator dies if energy reaches zero
            if (Energy <= 0)
            {
                grid.Cells[X, Y] = null;
                return;
            }

            // Attempt reproduction if energy is high enough
            if (Energy >= config.PredatorReproductionThreshold)
                HandleReproduction(grid, newOrganisms);
        }

        /// <summary>
        /// Finds the closest prey in vision range using Manhattan distance.
        /// Returns null if none found.
        /// </summary>
        private Prey FindClosestPrey(Grid grid)
        {
            Prey closest = null;
            int bestDist = int.MaxValue;

            for (int dx = -visionRange; dx <= visionRange; dx++)
            {
                for (int dy = -visionRange; dy <= visionRange; dy++)
                {
                    int nx = X + dx;
                    int ny = Y + dy;
                    if (grid.IsInside(nx, ny) && grid.Cells[nx, ny] is Prey prey)
                    {
                        int dist = System.Math.Abs(dx) + System.Math.Abs(dy);
                        if (dist < bestDist)
                        {
                            bestDist = dist;
                            closest = prey;
                        }
                    }
                }
            }

            return closest;
        }

        /// <summary>
        /// Moves one step closer to a target position.
        /// </summary>
        private (int x, int y) MoveTowardsTarget((int x, int y) target)
        {
            int dx = target.x - X;
            int dy = target.y - Y;

            // If horizontal distance is larger, move horizontally
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                return (X + Math.Sign(dx), Y);
            }
            // If vertical distance is larger, move vertically
            else if (Math.Abs(dy) > Math.Abs(dx))
            {
                return (X, Y + Math.Sign(dy));
            }
            else
            {
                // Distances are equal -> pick one randomly (to avoid diagonal)
                if (new Random().Next(2) == 0)
                    return (X + Math.Sign(dx), Y);
                else
                    return (X, Y + Math.Sign(dy));
            }
        }

        /// <summary>
        /// Chooses a random adjacent cell for movement.
        /// </summary>
        private (int x, int y) MoveRandom(System.Random rand)
        {
            var dirs = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
            var (dx, dy) = dirs[rand.Next(dirs.Length)];
            return (X + dx, Y + dy);
        }

        /// <summary>
        /// Attempts to move predator to a new cell.
        /// If the cell contains prey, it is eaten and predator gains energy.
        /// </summary>
        private void TryMove(Grid grid, int newX, int newY)
        {
            if (!grid.IsInside(newX, newY))
                return;

            var target = grid.Cells[newX, newY];

            if (target is Prey)
            {
                grid.Cells[newX, newY] = null; // eating
                Energy += config.PredatorEnergyGain;
                lastSeenPrey = null; // target eliminated
            }

            if (grid.Cells[newX, newY] == null)
            {
                grid.Cells[X, Y] = null; // leave current position
                X = newX; Y = newY;
                grid.Cells[X, Y] = this; // occupy new cell
            }
        }

        /// <summary>
        /// Handles reproduction if energy threshold is reached.
        /// Predator places a new predator in a random adjacent cell (if free).
        /// Parent's energy is split with offspring.
        /// </summary>
        private void HandleReproduction(Grid grid, List<Organism> newOrganisms)
        {
            var dirs = new (int dx, int dy)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            // Shuffle directions randomly
            foreach (var (dx2, dy2) in dirs.OrderBy(_ => System.Guid.NewGuid()))
            {
                int bx = X + dx2;
                int by = Y + dy2;
                if (grid.IsInside(bx, by) && grid.Cells[bx, by] == null)
                {
                    var baby = new Predator(bx, by, config);
                    newOrganisms.Add(baby);
                    Energy /= 2; // share energy with child
                    break;
                }
            }
        }

        /// <summary>
        /// Draws predator as a red square on the grid.
        /// </summary>
        public override void Draw(Graphics g, int cellSize)
        {
            g.FillRectangle(Brushes.Red, X * cellSize, Y * cellSize, cellSize, cellSize);
        }
    }
}
