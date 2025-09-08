using NUnit.Framework;
using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class PredatorTests
    {
        [Test]
        public void DiesWhenEnergyRunsOut()
        {
            var config = new SimulationConfig { PredatorEnergyGain = 0, PredatorReproductionThreshold = 100 };
            var grid = new Grid(5);
            var predator = new Predator(2, 2, config);
            grid.AddOrganism(predator);

            for (int i = 0; i < 10; i++)
                predator.Update(grid, new System.Random(), new List<Organism>());

            Assert.That(grid.Cells[2, 2], Is.Null);
        }
    }
}
