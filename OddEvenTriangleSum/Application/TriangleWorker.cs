using OddEvenTriangleSum.DataModels;
using OddEvenTriangleSum.Helpers;
using System;

namespace OddEvenTriangleSum.Application
{
    public interface ITriangleWorker
    {
        Triangle ProcessTriangle(string fileName);
    }
    public class TriangleWorker : ITriangleWorker
    {
        private readonly IFileReader _reader;
        public TriangleWorker(IFileReader reader)
        {
            _reader = reader;
        }

        public Triangle ProcessTriangle(string fileName)
        {
            var triangle = _reader.PopulateFromFile(fileName);

            if (triangle.IsEmpty || triangle.TriangleNodes == null)
            {
                Console.WriteLine("Nothing to process...");
            }
            else
            {
                CalculateTriangleSumData(triangle);
            }
            return triangle;
        }
        // Go bottom up, choose the child and merge the path memory with traversing up
        private void CalculateTriangleSumData(Triangle triangle)
        {
            var currentTriangleSize = triangle.TriangleSize;

            for (var i = currentTriangleSize - 2; i >= 0; i--)
            {
                var currentOneDimensionSize = triangle.TriangleNodes[i].Length;

                for (var j = 0; j < currentOneDimensionSize; j++)
                {
                    var chosenChild = TriangleHelper.ChooseSuitableChild(triangle, i, j);
                   
                    if (chosenChild != null)
                    {
                        MergeMemory(triangle.TriangleNodes[i][j], chosenChild);
                    }
                }
            }
        }

        private void MergeMemory(TriangleNode parent, TriangleNode child)
        {
            parent.NodeMemory.AddRange(child.NodeMemory);
        }
    }
}