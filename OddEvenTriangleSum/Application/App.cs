using OddEvenTriangleSum.Helpers;
using System;

namespace OddEvenTriangleSum.Application
{
    public class App
    {
        private readonly ITriangleWorker _worker;
        public App(ITriangleWorker worker)
        {
            _worker = worker;
        }
        public void Run()
        {
            var triangle = _worker.ProcessTriangle("data.txt");
            
            if (triangle.TriangleNodes.Length > 0)
            {
                var pathMemoryJoined = string.Join("-", triangle.FinalMemory);

                Console.WriteLine("Maximum possible sum is: " + triangle.FinalSum);
                Console.WriteLine("Maximum sum memory path is: " + pathMemoryJoined);
                Console.ReadKey();
            }
           
        }
    }
}
