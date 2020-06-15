using NUnit.Framework;
using OddEvenTriangleSum.Helpers;
using OddEvenTriangleSum.DataModels;
using OddEvenTriangleSumTests.Data;

namespace OddEvenTriangleSumTests.Application
{
    [TestFixture]
    public class TriangleHelperTests
    {
        [Test]
        public void ReturnsACorrectChild_WhenATriangleWithCorrectPathIsPresent()
        {
            var triangle = new Triangle(TriangleNodeData.triangleNodesCorrect);

            var child = TriangleHelper.ChooseSuitableChild(triangle, 0, 0);
            
            Assert.That(child.NodeValue, Is.EqualTo(8));

        }

        [Test]
        public void ReturnsNull_WhenATriangleWithoutACorrectPathIsPresent()
        {
            var triangle = new Triangle(TriangleNodeData.triangleNodesNoPath);

            var child = TriangleHelper.ChooseSuitableChild(triangle, 0, 0);

            Assert.That(child, Is.Null);

        }

        [Test]
        public void ReturnsAGreaterValueChild_WhenATriangleWithTwoCorrectChildrenIsPresent()
        {
            var triangle = new Triangle(TriangleNodeData.triangleNodesTwoConcurrentChildren);

            var child = TriangleHelper.ChooseSuitableChild(triangle, 0, 0);

            Assert.That(child.NodeValue, Is.EqualTo(12));

        }
    }
}