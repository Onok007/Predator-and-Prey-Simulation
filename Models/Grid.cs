namespace PredatorAndPreySimulation.Models
{
    /// <summary>
    /// Represents the 2D grid that contains all organisms.
    /// Provides utilities for bounds checking and placement of organisms.
    /// </summary>
    public class Grid
    {
        /// <summary>
        /// Size of the grid (width and height, since the grid is square).
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// 2D array storing organisms by their grid coordinates.
        /// Null means the cell is empty.
        /// </summary>
        public Organism[,] Cells { get; }

        /// <summary>
        /// Initializes a new grid with the given size.
        /// </summary>
        /// <param name="size">Number of cells along one dimension.</param>
        public Grid(int size)
        {
            Size = size;
            Cells = new Organism[size, size];
        }

        /// <summary>
        /// Checks if the given coordinates are inside the grid boundaries.
        /// </summary>
        public bool IsInside(int x, int y) =>
            x >= 0 && y >= 0 && x < Size && y < Size;

        /// <summary>
        /// Places an organism on the grid if the target cell is valid and empty.
        /// </summary>
        public void AddOrganism(Organism o)
        {
            if (IsInside(o.X, o.Y) && Cells[o.X, o.Y] == null)
                Cells[o.X, o.Y] = o;
        }
    }
}
