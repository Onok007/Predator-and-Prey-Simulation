using NUnit.Framework;
using PredatorAndPreySimulation.Models;
using System.Collections.Generic;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class OrganismTests
    {
        private class DummyOrganism : Organism
        {
            public DummyOrganism(int x, int y) : base(x, y) { }
            public override void Update(Grid grid, System.Random rand, List<Organism> newOrganisms) { }
            public override void Draw(System.Drawing.Graphics g, int cellSize) { }
        }

        [Test]
        public void StoresCoordinatesAndAge()
        {
            var o = new DummyOrganism(1, 2);

            Assert.That(o.X, Is.EqualTo(1));
            Assert.That(o.Y, Is.EqualTo(2));
            Assert.That(o.Age, Is.EqualTo(0));

            o.Age = 5;
            Assert.That(o.Age, Is.EqualTo(5));
        }
    }
}
