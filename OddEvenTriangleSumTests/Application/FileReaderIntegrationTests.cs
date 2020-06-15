using NUnit.Framework;
using OddEvenTriangleSum.Application;
using System;

namespace OddEvenTriangleSumTests.Application
{
    [TestFixture]
    public class FileReaderIntegrationTests
    {
        private FileReader reader = new FileReader();

        [Test]
        public void ReturnsEmptyTriangle_WhenFileFormatIsWrong()
        {
            var fileName = "Resources\\test_wrongdata.txt";

            var triangle = reader.PopulateFromFile(fileName);

            Assert.That(triangle.TriangleSize, Is.EqualTo(0));
        }

        [Test]
        public void ThrowsAnException_WhenFileNameIsNull()
        {
            string fileName = null;

            var exception = Assert.Throws<ArgumentException>(() => reader.PopulateFromFile(fileName));

            Assert.That(exception.Message, Is.EqualTo("Error! File Name is incorrect."));

        }

        [Test]
        public void ReturnsPopulatedTriangle_WhenFileFormatCorrect()
        {
            var fileName = "Resources\\test_correctdata.txt";

            var triangle = reader.PopulateFromFile(fileName);
            var rootNodeValue = triangle.TriangleNodes[0][0].NodeValue;

            Assert.That(triangle.TriangleNodes.Length, Is.EqualTo(3));
            Assert.That(rootNodeValue, Is.EqualTo(1));
        }
    }
}