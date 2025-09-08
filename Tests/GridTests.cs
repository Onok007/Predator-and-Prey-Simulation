using NUnit.Framework;
using PredatorAndPreySimulation.Models;

namespace PredatorAndPreySimulation.Tests
{
    [TestFixture]
    public class GridTests
    {
        [Test]
        public void IsInside_ReturnsExpectedResults()
        {
            var grid = new Grid(5);
            Assert.That(grid.IsInside(0, 0), Is.True);
            Assert.That(grid.IsInside(4, 4), Is.True);
            Assert.That(grid.IsInside(5, 5), Is.False);
            Assert.That(grid.IsInside(-1, 0), Is.False);
        }
    }
}
