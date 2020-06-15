using System.Linq;
using System.Collections.Generic;

namespace OddEvenTriangleSum.DataModels
{
    public class TriangleNode
    {
        public int NodeValue => NodeMemory.FirstOrDefault();
        public List<int> NodeMemory { get; set; }
        public int NodeSum => NodeMemory.Sum();
        public TriangleNode(int nodeValue)
        {
            NodeMemory = new List<int>
            {
                nodeValue
            };
        }
        
    }
}