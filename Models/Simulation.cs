using System;
using System.Drawing;
using System.Collections.Generic;
using PredatorAndPreySimulation.Persistence;

namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Core simulation engine managing grid, organisms, ticks, 
    /// drawing, saving and loading of the simulation state.
    /// </summary>
    public class Simulation
    {
        private Grid grid;
        private Random rand;
        private bool running;
        private readonly SimulationConfig config;

        /// <summary>
        /// Number of steps (ticks) since the simulation started.
        /// </summary>
        public int Tick { get; private set; }

        /// <summary>
        /// Whether the simulation is currently running (vs paused).
        /// </summary>
        public bool IsRunning => running;

        /// <summary>
        /// Size of the grid (number of cells per side).
        /// </summary>
        public int Size => grid.Size;

        /// <summary>
        /// Creates a new simulation with given parameters and populates it randomly.
        /// </summary>
        public Simulation(
            SimulationConfig config,
            int gridSize = 50,
            int preyCount = 100,
            int predatorCount = 20,
            int obstacleCount = 50)
        {
            this.config = config;
            rand = new Random();
            grid = new Grid(gridSize);
            Tick = 0;

            PlaceRandomOrganisms(preyCount, (x, y) => new Prey(x, y, config));
            PlaceRandomOrganisms(predatorCount, (x, y) => new Predator(x, y, config));
            PlaceRandomOrganisms(obstacleCount, (x, y) => new Obstacle(x, y));
        }

        /// <summary>
        /// Places organisms randomly on the grid with collision safety.
        /// Stops after a maximum attempt limit to prevent infinite loops.
        /// </summary>
        private void PlaceRandomOrganisms(int count, Func<int, int, Organism> factory)
        {
            int attempts = 0;
            int placed = 0;
            int maxAttempts = count * 20; // safety margin

            while (placed < count && attempts < maxAttempts)
            {
                int x = rand.Next(grid.Size);
                int y = rand.Next(grid.Size);

                if (grid.Cells[x, y] == null)
                {
                    grid.AddOrganism(factory(x, y));
                    placed++;
                }
                attempts++;
            }
        }

        /// <summary>
        /// Starts the simulation (continues ticking).
        /// </summary>
        public void Start() => running = true;

        /// <summary>
        /// Pauses the simulation.
        /// </summary>
        public void Pause() => running = false;

        /// <summary>
        /// Performs one step of the simulation:
        /// - collects all organisms
        /// - updates them
        /// - integrates newly born organisms
        /// </summary>
        public void Step()
        {
            Tick++;

            var organisms = CollectOrganisms();
            var newborns = new List<Organism>();

            foreach (var o in organisms)
            {
                if (grid.Cells[o.X, o.Y] == o) // ensure still alive
                    o.Update(grid, rand, newborns);
            }

            foreach (var baby in newborns)
                grid.AddOrganism(baby);
        }

        /// <summary>
        /// Collects all organisms currently present on the grid.
        /// </summary>
        private List<Organism> CollectOrganisms()
        {
            var organisms = new List<Organism>();
            for (int i = 0; i < grid.Size; i++)
                for (int j = 0; j < grid.Size; j++)
                    if (grid.Cells[i, j] != null)
                        organisms.Add(grid.Cells[i, j]);
            return organisms;
        }

        /// <summary>
        /// Draws the entire grid and organisms to a Graphics context.
        /// </summary>
        public void Draw(Graphics g, int panelWidth, int panelHeight)
        {
            int cellSize = Math.Min(panelWidth / grid.Size, panelHeight / grid.Size);
            g.Clear(Color.White);

            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    var o = grid.Cells[i, j];
                    o?.Draw(g, cellSize);
                }
            }
        }

        // --- Organism management API (for editor tools) ---

        public bool IsInside(int x, int y) => grid.IsInside(x, y);

        public void AddPrey(int x, int y)
        {
            if (IsInside(x, y) && grid.Cells[x, y] == null)
                grid.AddOrganism(new Prey(x, y, config));
        }

        public void AddPredator(int x, int y)
        {
            if (IsInside(x, y) && grid.Cells[x, y] == null)
                grid.AddOrganism(new Predator(x, y, config));
        }

        public void AddObstacle(int x, int y)
        {
            if (IsInside(x, y) && grid.Cells[x, y] == null)
                grid.AddOrganism(new Obstacle(x, y));
        }

        public void RemoveOrganism(int x, int y)
        {
            if (IsInside(x, y))
                grid.Cells[x, y] = null;
        }

        // --- Persistence ---

        /// <summary>
        /// Serializes simulation state (grid + organisms + config) into a DTO.
        /// </summary>
        public SimulationData ToData()
        {
            var data = new SimulationData
            {
                GridSize = this.Size,
                Config = this.config
            };

            for (int x = 0; x < this.Size; x++)
            {
                for (int y = 0; y < this.Size; y++)
                {
                    var o = this.grid.Cells[x, y];
                    if (o != null)
                    {
                        var od = new OrganismData
                        {
                            Type = o.GetType().Name,
                            X = o.X,
                            Y = o.Y,
                            Age = o.Age,
                            Energy = (o is Predator predator ? predator.Energy : 0)
                        };
                        data.Organisms.Add(od);
                    }
                }
            }

            return data;
        }

        /// <summary>
        /// Creates a new Simulation from serialized data.
        /// </summary>
        public static Simulation FromData(SimulationData data)
        {
            var sim = new Simulation(data.Config, data.GridSize);

            foreach (var od in data.Organisms)
            {
                Organism o = null;

                if (od.Type == nameof(Prey))
                {
                    o = new Prey(od.X, od.Y, sim.config) { Age = od.Age };
                }
                else if (od.Type == nameof(Predator))
                {
                    var p = new Predator(od.X, od.Y, sim.config) { Age = od.Age };
                    p.SetEnergy(od.Energy);
                    o = p;
                }
                else if (od.Type == nameof(Obstacle))
                {
                    o = new Obstacle(od.X, od.Y);
                }

                if (o != null)
                    sim.grid.Cells[o.X, o.Y] = o;
            }

            return sim;
        }

        // --- Statistics ---

        /// <summary>
        /// Counts current number of prey and predators in the grid.
        /// </summary>
        public (int prey, int predators) CountOrganisms()
        {
            int prey = 0, predators = 0;
            for (int x = 0; x < grid.Size; x++)
                for (int y = 0; y < grid.Size; y++)
                {
                    if (grid.Cells[x, y] is Prey) prey++;
                    else if (grid.Cells[x, y] is Predator) predators++;
                }
            return (prey, predators);
        }
    }
}
