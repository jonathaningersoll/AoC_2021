using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_SonarSweep
{
    public class SonarSweep
    {
        public void Run()
        {
            PartOne();
            //PartTwo();
        }

        private void PartOne()
        {
            //var input = File.ReadAllLines(@"./input.txt").Select(x => int.Parse(x)).ToList();
            var input = File.ReadAllLines(@"./input.txt").Select(int.Parse).ToList();

            var numberOfTimesDepthIncreases = CalculateDepthIncreases(input);

            Console.WriteLine(numberOfTimesDepthIncreases);
        }

        private void PartTwo()
        {
            var input = File.ReadAllLines(@"./input.txt").Select(x => int.Parse(x)).ToList();
            //var input = File.ReadAllLines(@"./testInput.txt").Select(x => int.Parse(x)).ToList();

            var slidingMeasurement = new List<int>();

            int iterator = 0;

            while(iterator < input.Count - 2)
            {
                var m = input.GetRange(iterator,3).Sum(x => x);
                Console.WriteLine(m);
                slidingMeasurement.Add(m);
                iterator++;
            }

            var numberOfTimesDepthIncreases = CalculateDepthIncreases(slidingMeasurement);

            Console.WriteLine(numberOfTimesDepthIncreases);
        }

        private int CalculateDepthIncreases(List<int> input)
        {
            int numberOfDepthIncreases = 0;
            int i = 1;
            while (i < input.Count())
            {
                if (input[i] > input[i - 1])
                {
                    numberOfDepthIncreases++;
                }
                i++;
            }

            return numberOfDepthIncreases;
        }
    }
}
