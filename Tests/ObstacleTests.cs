using NUnit.Framework;
using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class ObstacleTests
    {
        [Test]
        public void DoesNothingOnUpdate()
        {
            var grid = new Grid(5);
            var obstacle = new Obstacle(2, 2);
            grid.AddOrganism(obstacle);

            var newborns = new List<Organism>();
            obstacle.Update(grid, new System.Random(), newborns);

            Assert.That(grid.Cells[2, 2], Is.EqualTo(obstacle));
            Assert.That(newborns, Is.Empty);
        }
    }
}
