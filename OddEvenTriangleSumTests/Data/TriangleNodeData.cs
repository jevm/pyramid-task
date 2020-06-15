using OddEvenTriangleSum.DataModels;

namespace OddEvenTriangleSumTests.Data
{
    // Just a static class for storing pre-defined test data
    public static  class TriangleNodeData
    {
        public static TriangleNode[][] triangleNodesCorrect = new TriangleNode[][]
        {
            new TriangleNode[] {new TriangleNode(1)},
            new TriangleNode[] {new TriangleNode(8), new TriangleNode(9)},
            new TriangleNode[] {new TriangleNode(1), new TriangleNode(5), new TriangleNode(9)},
            new TriangleNode[] {new TriangleNode(4), new TriangleNode(5), new TriangleNode(2), new TriangleNode(3)}
        };
        public static TriangleNode[][] triangleNodesNoPath = new TriangleNode[][]
        {
            new TriangleNode[] {new TriangleNode(1)},
            new TriangleNode[] {new TriangleNode(3), new TriangleNode(9)}
        };
        public static TriangleNode[][] triangleNodesTwoConcurrentChildren = new TriangleNode[][]
        {
            new TriangleNode[] {new TriangleNode(1)},
            new TriangleNode[] {new TriangleNode(8), new TriangleNode(12)},
        };
    }
}
