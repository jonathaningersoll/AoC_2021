using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Dive
{
    public class Dive
    {
        public void Run()
        {
            PartOne();
            //PartTwo();
        }

        private void PartOne()
        {
            var input = File.ReadAllLines(@"./input.txt").ToList();
            //var input = File.ReadAllLines(@"./testInput.txt").ToList();

            // WORDY:
            //int forward = input.Where(x => x.Contains("forward")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum();
            //int depth = input.Where(x => x.Contains("down")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum();
            //depth = depth - input.Where(x => x.Contains("up")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum();
            //Console.WriteLine(depth*forward);

            Console.WriteLine((input.Where(x => x.Contains("down")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum() - input.Where(x => x.Contains("up")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum()) * input.Where(x => x.Contains("forward")).ToList().Select(x => int.Parse(x.Last().ToString())).Sum());

        }

        private void PartTwo()
        {
            var input = File.ReadAllLines(@"./input.txt").ToList();
            //var input = File.ReadAllLines(@"./testInput.txt").ToList();

            int forward = 0;
            int depth = 0;
            int aim = 0;

            input.ForEach(x =>
            {
                int amt = int.Parse(x.Last().ToString());
                if (x.Contains("forward"))
                {
                    forward += amt;
                    depth += aim * amt;
                }
                else if (x.Contains("down"))
                {
                    aim += amt;
                }
                else if (x.Contains("up"))
                {
                    aim -= amt;
                }
            });

            Console.WriteLine(forward * depth);
        }
    }
}
