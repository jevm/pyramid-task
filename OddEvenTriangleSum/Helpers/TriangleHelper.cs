using OddEvenTriangleSum.DataModels;
using System.Collections.Generic;

namespace OddEvenTriangleSum.Helpers
{
    // A helper class with different small methods
    public static class TriangleHelper
    {
        private static TriangleNode FindLeftChild(Triangle triangle, int i, int j) => triangle.TriangleNodes[i + 1][j];
        
        private static TriangleNode FindRightChild(Triangle triangle, int i, int j) => triangle.TriangleNodes[i + 1][j + 1];

        private static TriangleNode FindParent(Triangle triangle, int i, int j) => triangle.TriangleNodes[i][j];
        

        private static bool IsValidTraversal(TriangleNode parent, TriangleNode child)
        {
            if (parent.NodeValue % 2 == child.NodeValue % 2) return false;
            else return true;
        }

        // Compare parent and children, if only one is relevant, return it, if both are revelant choose maximum
        public static TriangleNode ChooseSuitableChild(Triangle triangle, int i, int j)
        {
            var currentParent = FindParent(triangle, i, j);
            var currentLeftChild = FindLeftChild(triangle, i, j);
            var currentRightChild = FindRightChild(triangle, i, j);
            TriangleNode result = null;

            if (IsValidTraversal(currentParent, currentLeftChild))
            {
                result = currentLeftChild;
            }

            if (IsValidTraversal(currentParent, currentRightChild))
            {
                if (result != null)
                {
                    result = currentRightChild.NodeSum > currentLeftChild.NodeSum ? currentRightChild : currentLeftChild;
                }
                else
                {
                    result = currentRightChild;
                }
            }
            return result;
        }
    }
}
