using System.Collections.Generic;

namespace OddEvenTriangleSum.DataModels
{
    public class Triangle
    {
        public TriangleNode[][] TriangleNodes { get; set; }
        public Triangle(TriangleNode[][] currentNodes) => TriangleNodes = currentNodes;
        public Triangle() 
        { }
        public int TriangleSize => TriangleNodes.Length;
        public bool IsEmpty => TriangleNodes.Length == 0;

        public int FinalSum => TriangleNodes[0][0].NodeSum;

        public List<int> FinalMemory => TriangleNodes[0][0].NodeMemory;
    }
}