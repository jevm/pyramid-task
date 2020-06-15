using OddEvenTriangleSum.DataModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace OddEvenTriangleSum.Application
{
    public interface IFileReader
    {
        Triangle PopulateFromFile(string fileName);
    }
    public class FileReader : IFileReader
    {
        // Populate the triangle structure nodes from text file, return empty array if exception
        public Triangle PopulateFromFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Error! File Name is incorrect.");
            }

            List<TriangleNode[]> nodes = new List<TriangleNode[]>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                   var valuesList = line.Split(" ");
                    TriangleNode[] lineNodes = new TriangleNode[valuesList.Length];

                    for (var i = 0; i < valuesList.Length; i++)
                    {
                        try
                        {
                            var numberValue = int.Parse(valuesList[i]);
                            lineNodes[i] = new TriangleNode(numberValue);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Error! Wrong file format. Error: " + ex.Message);
                            nodes.Clear();
                            return new Triangle(nodes.ToArray());
                        }
                    }
                    nodes.Add(lineNodes);
                }
            }
            return new Triangle(nodes.ToArray());
        }
    }
}
