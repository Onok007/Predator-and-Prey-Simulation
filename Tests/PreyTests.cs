using NUnit.Framework;
using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class PreyTests
    {
        [Test]
        public void ReproducesAfterEnoughSteps()
        {
            var config = new SimulationConfig { PreyReproductionRate = 1 };
            var grid = new Grid(10);
            var prey = new Prey(5, 5, config);
            grid.AddOrganism(prey);

            var newborns = new List<Organism>();
            prey.Update(grid, new System.Random(0), newborns);

            Assert.That(newborns.Count, Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void DiesFromOverpopulation()
        {
            var config = new SimulationConfig { PreyOverpopulationLimit = 1 };
            var grid = new Grid(3);

            var prey = new Prey(1, 1, config);
            grid.AddOrganism(prey);

            // surround by other prey
            grid.AddOrganism(new Prey(0, 1, config));
            grid.AddOrganism(new Prey(2, 1, config));

            prey.Update(grid, new System.Random(0), new List<Organism>());

            Assert.That(grid.Cells[1, 1], Is.Null);
        }
    }
}
