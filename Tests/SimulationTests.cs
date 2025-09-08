using NUnit.Framework;
using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class SimulationTests
    {
        [Test]
        public void Simulation_AddPrey_Works()
        {
            var config = new SimulationConfig();
            var sim = new Simulation(config, gridSize: 10, preyCount: 0, predatorCount: 0, obstacleCount: 0);

            sim.AddPrey(2, 2);

            Assert.That(sim.CountOrganisms().prey, Is.EqualTo(1));
        }
    }
}
