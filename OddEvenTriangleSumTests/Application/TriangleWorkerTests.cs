using Moq;
using NUnit.Framework;
using OddEvenTriangleSum.Application;
using OddEvenTriangleSum.DataModels;
using OddEvenTriangleSumTests.Data;

namespace OddEvenTriangleSumTests.Application
{
    [TestFixture]
    public class TriangleWorkerTests
    { 

        [Test]
        public void CalculatesSum_WhenATriangleWithCorrectPathIsPresent()
        {
            AssertTriangleSum("good_data.txt", 16);
        }

        [Test]
        public void CalculatesABiggerSum_WhenATriangleWithTwoCorrectPathsIsPresent()
        {
            AssertTriangleSum("concurrent_data.txt", 13);
        }

        [Test]
        public void LeavesSumAsRootValue_WhenNoPathsAreAvailable()
        {
            AssertTriangleSum("bad_data.txt", 1);
        }

        public TriangleWorker CreateTriangleWorker(TriangleNode[][] triangleNodes)
        {
            Mock<IFileReader> reader = new Mock<IFileReader>();
            reader.Setup(r => r.PopulateFromFile(It.IsAny<string>())).Returns(new Triangle(triangleNodes));
            var worker = new TriangleWorker(reader.Object);
            return worker;
        }

        public void AssertTriangleSum(string fileName, int expectedResult)
        {
            TriangleWorker worker = null;

            switch (fileName)
            {
                case "good_data.txt":
                    worker = CreateTriangleWorker(TriangleNodeData.triangleNodesCorrect);
                    break;
                case "bad_data.txt":
                    worker = CreateTriangleWorker(TriangleNodeData.triangleNodesNoPath);
                    break;
                case "concurrent_data.txt":
                    worker = CreateTriangleWorker(TriangleNodeData.triangleNodesTwoConcurrentChildren);
                    break;
            }

            if (worker != null)
            {
                var triangle = worker.ProcessTriangle(fileName);

                Assert.That(triangle.FinalSum, Is.EqualTo(expectedResult));
            }
            else
            {
                Assert.Fail("Wrong file name is provided.");
            }
        }
    }
}