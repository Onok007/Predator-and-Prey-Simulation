using PredatorAndPreySimulation.Models;
using System.Collections.Generic;
using System.Drawing;
using System;


/// <summary>
/// Base class for all entities in the simulation (prey, predator, obstacle).
/// Provides position, age, and abstract methods for behavior and rendering.
/// </summary>
public abstract class Organism
{
    /// <summary>
    /// X coordinate on the grid.
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Y coordinate on the grid.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Age of the organism in simulation steps.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Creates an organism at the given grid coordinates.
    /// </summary>
    protected Organism(int x, int y)
    {
        X = x;
        Y = y;
        Age = 0;
    }

    /// <summary>
    /// Updates the organism's state (movement, reproduction, etc.).
    /// Implemented individually by subclasses.
    /// </summary>
    /// <param name="grid">The grid where organisms live.</param>
    /// <param name="rand">Random number generator for stochastic behavior.</param>
    /// <param name="newOrganisms">List to which newborn organisms can be added.</param>
    public abstract void Update(Grid grid, Random rand, List<Organism> newOrganisms);

    /// <summary>
    /// Draws the organism on the graphics context.
    /// </summary>
    /// <param name="g">Graphics object for rendering.</param>
    /// <param name="cellSize">Size of one cell in pixels.</param>
    public abstract void Draw(Graphics g, int cellSize);
}
