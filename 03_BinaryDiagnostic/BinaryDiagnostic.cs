using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BinaryDiagnostic
{
    public class BinaryDiagnostic
    {
        public void Run()
        {
            PartOneRedo();
            //PartOne();
            PartTwo();
        }


        private void PartOneRedo()
        {
            var input = File.ReadAllLines(@"./input.txt").ToList();

            string[] gamma = new string[12];
            string[] epsilon = new string[12];

            for (int i = 0; i < input[0].Count(); i++)
            {
                gamma[i] = input.Where(x => x[i] == '1').Count() > (input.Count() / 2) ? "1" : "0";
            }

            for (int i = 0; i < input[0].Count(); i++)
            {
                epsilon[i] = input.Where(x => x[i] == '1').Count() < (input.Count() / 2) ? "1" : "0";
            }

            var gammaValue = ConvertToDecimal(string.Join("", gamma));
            var epsilonValue = ConvertToDecimal(string.Join("", epsilon));

            Console.WriteLine(gammaValue);
            Console.WriteLine(epsilonValue);
            Console.WriteLine(gammaValue* epsilonValue);
            Console.ReadKey();
        }

        private void PartOne()
        {
            var input = File.ReadAllLines(@"./input.txt").ToList();

            int[] gamma = new int[12];
            int[] epsilon = new int[12];

            //for(int i = 0; i < 12; i++)
            //{
            //    gamma[i] = input.Where(x => x[i] == '1').Count() > (input.Count() / 2) ? 2048 : 0;
            //}



            gamma[0] = input.Where(x => x[0] == '1').Count() > (input.Count() / 2) ? 2048 : 0;
            gamma[1] = input.Where(x => x[1] == '1').Count() > (input.Count() / 2) ? 1024 : 0;
            gamma[2] = input.Where(x => x[2] == '1').Count() > (input.Count() / 2) ? 512 : 0;
            gamma[3] = input.Where(x => x[3] == '1').Count() > (input.Count() / 2) ? 256 : 0;
            gamma[4] = input.Where(x => x[4] == '1').Count() > (input.Count() / 2) ? 128 : 0;
            gamma[5] = input.Where(x => x[5] == '1').Count() > (input.Count() / 2) ? 64 : 0;
            gamma[6] = input.Where(x => x[6] == '1').Count() > (input.Count() / 2) ? 32 : 0;
            gamma[7] = input.Where(x => x[7] == '1').Count() > (input.Count() / 2) ? 16 : 0;
            gamma[8] = input.Where(x => x[8] == '1').Count() > (input.Count() / 2) ? 8 : 0;
            gamma[9] = input.Where(x => x[9] == '1').Count() > (input.Count() / 2) ? 4 : 0;
            gamma[10] = input.Where(x => x[10] == '1').Count() > (input.Count() / 2) ? 2 : 0;
            gamma[11] = input.Where(x => x[11] == '1').Count() > (input.Count() / 2) ? 1 : 0;

            epsilon[0] = input.Where(x => x[0] == '1').Count() < (input.Count() / 2) ? 2048 : 0;
            epsilon[1] = input.Where(x => x[1] == '1').Count() < (input.Count() / 2) ? 1024 : 0;
            epsilon[2] = input.Where(x => x[2] == '1').Count() < (input.Count() / 2) ? 512 : 0;
            epsilon[3] = input.Where(x => x[3] == '1').Count() < (input.Count() / 2) ? 256 : 0;
            epsilon[4] = input.Where(x => x[4] == '1').Count() < (input.Count() / 2) ? 128 : 0;
            epsilon[5] = input.Where(x => x[5] == '1').Count() < (input.Count() / 2) ? 64 : 0;
            epsilon[6] = input.Where(x => x[6] == '1').Count() < (input.Count() / 2) ? 32 : 0;
            epsilon[7] = input.Where(x => x[7] == '1').Count() < (input.Count() / 2) ? 16 : 0;
            epsilon[8] = input.Where(x => x[8] == '1').Count() < (input.Count() / 2) ? 8 : 0;
            epsilon[9] = input.Where(x => x[9] == '1').Count() < (input.Count() / 2) ? 4 : 0;
            epsilon[10] = input.Where(x => x[10] == '1').Count() < (input.Count() / 2) ? 2 : 0;
            epsilon[11] = input.Where(x => x[11] == '1').Count() < (input.Count() / 2) ? 1 : 0;

            Console.WriteLine(gamma.Sum());
            Console.WriteLine(epsilon.Sum());

            Console.WriteLine("Computed value: " + gamma.Sum()*epsilon.Sum());
        }

        private void PartTwo()
        {
            var masterInput = File.ReadAllLines(@"./input.txt").ToList();
            //var masterInput = File.ReadAllLines(@"./testInput.txt").ToList();

            Console.WriteLine(CalculateOxygen(masterInput)*CalculateCO2(masterInput));
        }

        private double CalculateOxygen(List<string> input)
        {
            var oxygenInput = input.ToList();

            int[] oxygen = new int[oxygenInput[1].Length];

            // OXYGEN
            for (int i = 0; i < oxygen.Length; i++)
            {
                var columnList = oxygenInput.Select(x => int.Parse(x[i].ToString())).ToList();
                oxygen[i] = columnList.Where(x => x == 1).Count() >= columnList.Where(x => x == 0).Count() ? 1 : 0;
                oxygenInput.RemoveAll(x => x[i].ToString() != oxygen[i].ToString());
            }

            return ConvertToDecimal(oxygenInput[0]);
        }

        private double CalculateCO2(List<string> input)
        {
            var co2Input = input.ToList();
            int[] coTwo = new int[co2Input[1].Length];
            int i = 0;
            // CO2
            while(co2Input.Count() > 1)
            {
                var columnList = co2Input.Select(x => int.Parse(x[i].ToString())).ToList();
                int ones = columnList.Where(x => x == 1).Count();
                int zeros = columnList.Where(x => x == 0).Count();
                
                if (ones < zeros)
                {
                    coTwo[i] = 1;
                }
                else
                {
                    coTwo[i] = 0;
                }
                co2Input.RemoveAll(x => x[i].ToString() != coTwo[i].ToString());
                i++;
            }

            return ConvertToDecimal(co2Input[0]);
        }

        private double ConvertToDecimal(string bin)
        {
            var reversedBinary = bin.Reverse().ToArray();
            double amt = 0;

            for (int i = 0; i < reversedBinary.Count(); i++)
            {
                amt += reversedBinary[i].ToString() == "1" ? Math.Pow(2, i) : 0;
            }

            return amt;
        }

    }
}